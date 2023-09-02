CREATE OR REPLACE PROCEDURE "proc_delete_category"(
  "p_id"   UUID
)
  LANGUAGE plpgsql
AS $$
BEGIN
  DELETE FROM "articles_categories" as ac
  WHERE ac."subcategory_id" IN (
    SELECT
      s."id"
    FROM "subcategories" as s
    WHERE s."category_id" = "p_id"
  );
  
  DELETE FROM "subcategories"
  WHERE "category_id" = "p_id";
  
  DELETE FROM "categories"
  WHERE "id" = "p_id";
END;$$