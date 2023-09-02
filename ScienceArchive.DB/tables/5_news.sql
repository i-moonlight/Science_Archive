-- News

CREATE TABLE IF NOT EXISTS "news" (
  "id"    UUID         NOT NULL,
  "title" VARCHAR(255) NOT NULL,
  "body"  TEXT         NOT NULL,

  PRIMARY KEY ("id")
);

CREATE INDEX IF NOT EXISTS idx__news__title
  ON "news" ("title"); 
