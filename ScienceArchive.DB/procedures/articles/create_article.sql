CREATE OR REPLACE PROCEDURE "proc_create_article" (
  "p_id"                UUID,
  "p_title"             VARCHAR(255),
  "p_user_id"           UUID,
  "p_created_timestamp" TIMESTAMP WITH TIME ZONE,
  "p_description"       TEXT,
  "p_document_path"     VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
BEGIN
  INSERT INTO "articles" (
    "id", 
    "title", 
    "description"
  ) VALUES (
    "p_id",
    "p_title",
    "p_description"
  );
  
  INSERT INTO "articles_creation" (
    "article_id", 
    "author_id", 
    "created_timestamp"
  ) VALUES (
    "p_id",
    "p_user_id",
    "p_created_timestamp"
  ); 
  
  IF "p_document_path" IS NOT NULL
  THEN
    INSERT INTO "articles_documents" (
      "article_id", 
      "document_path"
    ) VALUES (
      "p_id",
      "p_document_path"
    );
  END IF;
END;$$