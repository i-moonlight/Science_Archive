CREATE OR REPLACE FUNCTION "func_get_all_users" ()
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

  RETURN QUERY
  SELECT
    u."id",
    u."name",
    u."email",
    ua."login"
  FROM "users"              AS u
    INNER JOIN "users_auth" AS ua ON ua."user_id" = u."id";

END;$$