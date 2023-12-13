CREATE OR REPLACE FUNCTION "func_get_category_by_id" (
  "p_id" UUID
)
RETURNS TABLE (
  "id"            UUID,
  "name"          VARCHAR(255),
  "subcategories" JSONB  
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
    SELECT
      c."id",
      c."name",
      (
        SELECT
          jsonb_agg(
            json_build_object(
              'id',   sc."id",
              'name', sc."name"
            )
          )
        FROM "subcategories" as sc
        WHERE sc."category_id" = c."id"
      )
    FROM "categories" as c
    WHERE c."id" = "p_id";
END;$$