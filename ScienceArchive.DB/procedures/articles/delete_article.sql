CREATE OR REPLACE PROCEDURE "proc_delete_article" (
  "p_id" UUID
)
LANGUAGE plpgsql
AS $$
BEGIN
  DELETE FROM "articles_creation"
  WHERE "article_id" = "p_id";

  DELETE FROM "articles_documents"
  WHERE "article_id" = "p_id";
  
  DELETE FROM "articles"
  WHERE "id" = "p_id";
END;$$