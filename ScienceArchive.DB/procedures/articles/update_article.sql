CREATE OR REPLACE PROCEDURE "proc_update_article" (
  "p_id"                UUID,
  "p_title"             VARCHAR(255),
  "p_description"       TEXT,
  "p_document_path"     VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
BEGIN
  UPDATE "articles" AS a
  SET
    "title"       = COALESCE("p_title", a."title"),
    "description" = COALESCE("p_description", a."description")
  WHERE "id" = "p_id";
  
  UPDATE "articles_documents" AS ad
  SET
    "document_path" = COALESCE("p_document_path", ad."document_path")
  WHERE "article_id" = "p_id";
END;$$