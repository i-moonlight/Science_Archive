-- Relation between categories with each other

CREATE TABLE IF NOT EXISTS "articles_authors" (
  "article_id" UUID NOT NULL,
  "author_id"  UUID NOT NULL,
  
  PRIMARY KEY ("article_id", "author_id"),
  
  CONSTRAINT "idx__articles_authors__articles_id__articles__id"
    FOREIGN KEY ("article_id")
    REFERENCES "articles" ("id"),
  
  CONSTRAINT "idx__articles_authors__author_id__users__id"
    FOREIGN KEY ("author_id")
    REFERENCES "users" ("id")
);