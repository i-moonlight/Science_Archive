CREATE OR REPLACE FUNCTION "func_create_article" (
  "p_id"                UUID,
  "p_title"             VARCHAR(255),
  "p_user_id"           UUID,
  "p_created_timestamp" TIMESTAMP WITH TIME ZONE,
  "p_description"       TEXT,
  "p_document_path"     VARCHAR(255)
)
RETURNS TABLE (
  "id"            UUID,
  "title"         VARCHAR(255),
  "author"        users,
  "creation_date" TIMESTAMP WITH TIME ZONE,
  "description"   TEXT,
  "document_path" VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_create_article" (
    "p_id",
    "p_title",
    "p_user_id",
    "p_created_timestamp",
    "p_description",
    "p_document_path"
  );
  
  RETURN QUERY 
  SELECT
    a."id",
    a."title",
    ROW(u.*) as "author",
    ac."created_timestamp" as "creation_date",
    a."description",
    ad."document_path"
  FROM "articles" AS a 
    INNER JOIN "articles_creation" AS ac on ac."article_id" = a."id"
    INNER JOIN "users" AS u ON u."id" = ac."author_id"
    LEFT JOIN "articles_documents" AS ad on ad."article_id" = a."id"
  WHERE a."id" = "p_id";
END;$$