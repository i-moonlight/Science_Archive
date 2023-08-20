CREATE OR REPLACE FUNCTION "func_delete_user" (
  "p_id" UUID
)
RETURNS UUID
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_delete_user"("p_id");
  RETURN "p_id";
END;$$