CREATE OR REPLACE PROCEDURE "proc_update_category"(
  "p_id"   UUID,
  "p_name" VARCHAR(255)
)
  LANGUAGE plpgsql
AS $$
BEGIN
  UPDATE "categories"
  SET 
    "name" = "p_name"
  WHERE "id" = "p_id";
END;$$