CREATE OR REPLACE FUNCTION "func_update_news" (
  "p_id"    UUID,
  "p_title" VARCHAR(255),
  "p_body"  TEXT
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
  CALL "proc_update_news" (
    "p_id",
    "p_title",
    "p_body"
  );

  RETURN QUERY
    SELECT * FROM "func_get_news_by_id"("p_id");
END;$$
