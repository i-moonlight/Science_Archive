CREATE OR REPLACE FUNCTION "func_create_news" (
  "p_id"                UUID,
  "p_title"             VARCHAR(255),
  "p_body"              TEXT,
  "p_user_id"           UUID,
  "p_created_timestamp" TIMESTAMP WITH TIME ZONE
)
RETURNS TABLE (
  "id"                UUID,
  "authorId"          UUID,
  "title"             VARCHAR(255),
  "body"              TEXT,
  "creationDate"      TIMESTAMP WITH TIME ZONE
)
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_create_news" (
    "p_id",
    "p_title",
    "p_body",
    "p_user_id",
    "p_created_timestamp"
  );
  
  RETURN QUERY 
    SELECT * FROM "func_get_news_by_id"("p_id");
END;$$
