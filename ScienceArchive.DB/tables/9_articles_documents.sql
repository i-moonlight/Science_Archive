-- Documents linked to articles

CREATE TABLE IF NOT EXISTS "articles_documents" (
  "article_id"    UUID NOT NULL,
  "document_path" VARCHAR(255) NOT NULL,
  
  PRIMARY KEY ("article_id"),
  
  CONSTRAINT "FK__articles_documents__article_id__articles__id"
    FOREIGN KEY ("article_id")
    REFERENCES "articles" ("id")
);
