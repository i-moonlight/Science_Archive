CREATE OR REPLACE FUNCTION "func_delete_article" (
  "p_id" UUID
)
RETURNS UUID
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_delete_article" ("p_id");
  RETURN "p_id";
END;$$