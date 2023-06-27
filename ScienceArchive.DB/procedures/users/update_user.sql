CREATE OR REPLACE PROCEDURE "proc_update_user"(
    "p_id"            UUID,
    "p_name"          VARCHAR(100),
    "p_email"         VARCHAR(50),
    "p_login"         VARCHAR(30),
    "p_password"      VARCHAR(255),
    "p_password_salt" VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
BEGIN
  UPDATE "users" as u
  SET
    "name" = COALESCE("p_name", u."name"),
    "email" = COALESCE("p_email", u."email")
  WHERE u."id" = "p_id";
  
  UPDATE "users_auth" as ua
  SET
    "login" = COALESCE("p_login", ua."login"),
    "password" = COALESCE("p_password", ua."password"),
    "password_salt" = COALESCE("p_password_salt", ua."password_salt")
  WHERE ua."user_id" = "p_id";
END;$$