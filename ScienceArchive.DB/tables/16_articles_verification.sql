-- Articles verification data

CREATE TABLE IF NOT EXISTS "articles_verification" (
  "article_id"   UUID      NOT NULL,
  "status"       INT       NOT NULL,
  "last_updated" TIMESTAMP NOT NULL,

  PRIMARY KEY ("article_id"),

  CONSTRAINT "idx__articles_verification__article_id__articles__id"
    FOREIGN KEY ("article_id")
      REFERENCES "articles" ("id")
);
