CREATE OR REPLACE FUNCTION "func_create_category" (
  "p_id"   UUID,
  "p_name" VARCHAR(255)
)
RETURNS TABLE (
  "id"            UUID,
  "name"          VARCHAR(255),
  "subcategories" JSONB
)
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_create_category"("p_id", "p_name");
  
  RETURN QUERY
    SELECT * FROM "func_get_category_by_id"("p_id");
END;$$