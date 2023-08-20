-- Articles creation data

CREATE TABLE IF NOT EXISTS "articles_creation" (
  "article_id"        UUID                     NOT NULL,
  "created_timestamp" TIMESTAMP WITH TIME ZONE NOT NULL,
  
  PRIMARY KEY ("article_id"),
  
  CONSTRAINT "FK__articles_creation__article_id__articles__id"
    FOREIGN KEY ("article_id")
    REFERENCES "articles" ("id")
);
