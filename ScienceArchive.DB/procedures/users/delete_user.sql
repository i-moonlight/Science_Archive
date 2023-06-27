CREATE OR REPLACE PROCEDURE "proc_delete_user"(
  "p_id" UUID
)
LANGUAGE plpgsql
AS $$
BEGIN
  DELETE FROM "users_roles" as ur
  WHERE ur."user_id" = "p_id";

  DELETE FROM "users_auth" as ua
  WHERE ua."user_id" = "p_id";
  
  DELETE FROM "users" as u
  WHERE u."id" = "p_id";
END;$$