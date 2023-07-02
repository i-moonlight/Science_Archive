CREATE OR REPLACE PROCEDURE "proc_create_news" (
  "p_id"                UUID,
  "p_title"             VARCHAR(255),
  "p_body"              TEXT,
  "p_user_id"           UUID,
  "p_created_timestamp" TIMESTAMP WITH TIME ZONE
)
LANGUAGE plpgsql
AS $$
BEGIN
  INSERT INTO "news" (
    "id", 
    "title", 
    "body"
  ) VALUES (
    "p_id",
    "p_title",
    "p_body"
  );
  
  INSERT INTO "news_creation" (
    "news_id", 
    "author_id", 
    "created_timestamp"
  ) VALUES (
    "p_id",
    "p_user_id",
    "p_created_timestamp"
  );
END;$$