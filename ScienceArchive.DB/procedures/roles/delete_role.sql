CREATE OR REPLACE PROCEDURE "proc_delete_role" (
  "p_id" UUID
)
LANGUAGE plpgsql
AS $$
BEGIN
  DELETE FROM "roles_claims"
  WHERE "role_id" = "p_id";
  
  DELETE FROM "users_roles"
  WHERE "role_id" = "p_id";
  
  DELETE FROM "roles"
  WHERE "id" = "p_id";
END $$