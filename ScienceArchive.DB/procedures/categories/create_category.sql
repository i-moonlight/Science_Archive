CREATE OR REPLACE PROCEDURE "proc_create_category"(
  "p_id"   UUID,
  "p_name" VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
BEGIN
  INSERT INTO "categories" (
    "id", 
    "name"
  )
  SELECT
    "p_id",
    "p_name";
END;$$