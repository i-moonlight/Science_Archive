CREATE OR REPLACE PROCEDURE "proc_create_user"(
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
  INSERT INTO "users" (
    "id",
    "name", 
    "email"
  ) VALUES (
    "p_id",
    "p_name",
    "p_email"
  );
  
  INSERT INTO "users_auth" (
    "user_id", 
    "login", 
    "password", 
    "password_salt"
  ) VALUES (
    "p_id",
    "p_login",
    "p_password",
    "p_password_salt"
  );
END;$$
