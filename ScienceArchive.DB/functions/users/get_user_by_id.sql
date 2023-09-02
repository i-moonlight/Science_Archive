CREATE OR REPLACE FUNCTION "func_get_user_by_id" (
  "p_id" UUID
)
RETURNS TABLE (
  "id"            UUID,
  "name"          VARCHAR(100),
  "email"         VARCHAR(50),
  "login"         VARCHAR(30),
  "rolesIds"      UUID[]
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
    SELECT
      u."id",
      u."name",
      u."email",
      ua."login",
      (
        SELECT
          array_agg(ur."role_id")
        FROM "users_roles" AS ur
        WHERE ur."user_id" = "p_id"
      )
    FROM "users"              AS u
      INNER JOIN "users_auth" AS ua ON ua."user_id" = u."id"
    WHERE u."id" = "p_id";
END;$$