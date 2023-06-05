CREATE OR REPLACE FUNCTION "get_users_with_passwords" ()
RETURNS TABLE
(
	"id" UUID,
	"name" VARCHAR(100),
	"email" VARCHAR(50),
	"login"	VARCHAR(30),
  "password" VARCHAR(255),
  "passwordSalt" VARCHAR(255)
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
    ua."password",
    ua."password_salt" as "passwordSalt"
	FROM "users"              AS u
		INNER JOIN "users_auth" AS ua ON ua."user_id" = u."id";

END;$$