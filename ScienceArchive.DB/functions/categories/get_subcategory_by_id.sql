CREATE OR REPLACE FUNCTION "func_get_subcategory_by_id" (
  "p_id" UUID
)
RETURNS TABLE (
  "id"            UUID,
  "name"          VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
BEGIN
RETURN QUERY
SELECT
    s."id",
    s."name"
FROM "subcategories" as s
WHERE s."id" = "p_id";
END;$$