DROP FUNCTION IF EXISTS "func_update_article";

CREATE OR REPLACE FUNCTION "func_update_article" (
  "p_id"                 UUID,
  "p_category_id"        UUID,
  "p_title"              VARCHAR(255),
  "p_description"        TEXT,
  "p_authors_ids"        UUID[],
  "p_documents"          JSONB,
  "p_status"             INT
)
RETURNS TABLE (
  "id"                UUID,
  "categoryId"        UUID,
  "title"             VARCHAR(255),
  "description"       TEXT,
  "creationDate"      TIMESTAMP,
  "authorsIds"        UUID[],
  "documents"         JSONB,
  "status"            INT
)
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_update_article" (
    "p_id",
    "p_category_id",
    "p_title",
    "p_description",
    "p_authors_ids",
    "p_documents",
    "p_status"
  );

  RETURN QUERY 
    SELECT * 
    FROM "func_get_article_by_id"("p_id");
END;$$