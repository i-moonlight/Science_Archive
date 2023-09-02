CREATE OR REPLACE FUNCTION "func_delete_category" (
  "p_id"   UUID
)
RETURNS UUID
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_delete_category"("p_id");
  
  RETURN "p_id";
END;$$