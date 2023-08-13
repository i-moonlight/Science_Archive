-- Relation between articles and categories

CREATE TABLE IF NOT EXISTS "articles_categories" (
  "article_id"  UUID NOT NULL,
  "category_id" UUID NOT NULL,
    
  PRIMARY KEY ("article_id", "category_id"),

  CONSTRAINT "idx__articles_categories__article_id__articles__id"
    FOREIGN KEY ("article_id") 
    REFERENCES "articles" ("id")
);