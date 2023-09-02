CREATE OR REPLACE PROCEDURE "proc_delete_news" (
  "p_id" UUID
)
LANGUAGE plpgsql
AS $$
BEGIN
  DELETE FROM "news_creation"
  WHERE "news_id" = "p_id";
  
  DELETE FROM "news"
  WHERE "id" = "p_id";
END;$$