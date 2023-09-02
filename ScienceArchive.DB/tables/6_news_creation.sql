-- News creation data

CREATE TABLE IF NOT EXISTS "news_creation" (
  "news_id"           UUID      NOT NULL,
  "author_id"         UUID      NOT NULL,
  "created_timestamp" TIMESTAMP NOT NULL,
  
  PRIMARY KEY ("news_id"),
  
  CONSTRAINT "FK__news_creation__news_id__news__id"
    FOREIGN KEY ("news_id")
    REFERENCES "news" ("id")
);
