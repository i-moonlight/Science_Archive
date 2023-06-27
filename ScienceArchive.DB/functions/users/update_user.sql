CREATE OR REPLACE FUNCTION "func_update_user" (
    "p_id"            UUID,
    "p_name"          VARCHAR(100),
    "p_email"         VARCHAR(50),
    "p_login"         VARCHAR(30),
    "p_password"      VARCHAR(255),
    "p_password_salt" VARCHAR(255)
)
    RETURNS TABLE
            (
                "id"    UUID,
                "name"  VARCHAR(100),
                "email" VARCHAR(50),
                "login" VARCHAR(30)
            )
    LANGUAGE plpgsql
AS $$
BEGIN

  CALL "proc_update_user"(
    "p_id",
    "p_name",
    "p_email",
    "p_login",
    "p_password",
    "p_password_salt"
  );

  RETURN QUERY
    SELECT
      u."id",
      u."name",
      u."email",
      ua."login"
    FROM "users"              AS u
      INNER JOIN "users_auth" AS ua ON ua."user_id" = u."id"
    WHERE u."id" = "p_id";

END;$$