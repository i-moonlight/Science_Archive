DROP PROCEDURE IF EXISTS "proc_create_article";

CREATE OR REPLACE PROCEDURE "proc_create_article" (
  "p_id"                UUID,
  "p_category_id"       UUID,
  "p_authors_ids"       UUID[],
  "p_title"             VARCHAR(255),
  "p_created_timestamp" TIMESTAMP,
  "p_description"       TEXT,
  "p_documents"         JSONB,
  "p_status"            INT
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
  
  INSERT INTO "articles" (
    "id", 
    "title", 
    "description"
  )
  SELECT
    "p_id",
    "p_title",
    "p_description";
  
  
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
  
  
  INSERT INTO "articles_creation" (
    "article_id", 
    "created_timestamp"
  ) 
  SELECT
    "p_id",
    "p_created_timestamp";
  
  
  INSERT INTO "articles_verification" (
    "article_id",
    "status", 
    "last_updated"
  )
  SELECT
    "p_id",
    "p_status",
    now();
  
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