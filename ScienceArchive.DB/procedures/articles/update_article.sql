CREATE OR REPLACE PROCEDURE "proc_update_article" (
  "p_id"                 UUID,
  "p_category_id"        UUID,
  "p_title"              VARCHAR(255),
  "p_description"        TEXT,
  "p_authors_ids"        UUID[],
  "p_documents"          JSONB
)
LANGUAGE plpgsql
AS $$
BEGIN
  DROP TABLE IF EXISTS "tmp_documents";

  CREATE TEMPORARY TABLE "tmp_documents" (
    "document_path" VARCHAR(255)
  );

  INSERT INTO "tmp_documents" (
    "document_path"
  )
  SELECT
    docs.document_path
  FROM jsonb_to_recordset("p_documents") AS docs("document_path" VARCHAR(255));

  UPDATE "articles" AS a
  SET
    "title"       = COALESCE("p_title", a."title"),
    "description" = "p_description"
  WHERE a."id" = "p_id";
  
  DELETE FROM "articles_authors" AS aa
  WHERE aa."article_id" = "p_id";
  
  DELETE FROM "articles_categories" AS ac
  WHERE ac."article_id" = "p_id";
  
  DELETE FROM "articles_documents" AS ad
  WHERE ad."article_id" = "p_id";

  INSERT INTO "articles_authors" (
    "article_id",
    "author_id"
  )
  SELECT
    "p_id",
    "author_id"
  FROM unnest("p_authors_ids") as "author_id";

  INSERT INTO "articles_categories" (
    "article_id",
    "subcategory_id"
  )
  SELECT
    "p_id",
    "p_category_id";

  INSERT INTO "articles_documents" (
    "article_id",
    "document_path"
  )
  SELECT
    "p_id",
    td."document_path"
  FROM "tmp_documents" as td;

  DROP TABLE IF EXISTS "tmp_documents";
END;$$