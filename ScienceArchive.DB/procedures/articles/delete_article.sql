CREATE OR REPLACE PROCEDURE "proc_delete_article" (
  "p_id" UUID
)
LANGUAGE plpgsql
AS $$
BEGIN  
  DELETE FROM "articles_categories" AS ac
  WHERE ac."article_id" = "p_id";
  
  DELETE FROM "articles_documents" AS ad
  WHERE ad."article_id" = "p_id";
  
  DELETE FROM "articles_authors" AS aa
  WHERE aa."article_id" = "p_id";
  
  DELETE FROM "articles_creation" AS ac
  WHERE ac."article_id" = "p_id";

  DELETE FROM "articles" AS a
  WHERE a."id" = "p_id";
END;$$