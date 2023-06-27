CREATE OR REPLACE FUNCTION "func_get_user_by_id" (
  "p_id" UUID
)
RETURNS TABLE
(
  "id"            UUID,
  "name"          VARCHAR(100),
  "email"         VARCHAR(50),
  "login"         VARCHAR(30),
  "password"      VARCHAR(255),
  "password_salt" VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
BEGIN

  SELECT
    u."id",
    u."name",
    u."email",
    ua."login",
    ua."password",
    ua."password_salt"
  FROM "users"              AS u
    INNER JOIN "users_auth" AS ua ON ua."user_id" = u."id"
  WHERE u."id" = "p_id";

END;$$