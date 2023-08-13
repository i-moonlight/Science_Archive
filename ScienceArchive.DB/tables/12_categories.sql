-- Categories

CREATE TABLE IF NOT EXISTS "categories" (
  "id"   UUID         NOT NULL,
  "name" VARCHAR(255) NOT NULL,

  PRIMARY KEY ("id")
);

CREATE INDEX IF NOT EXISTS "idx__categories__name"
  ON "categories" ("name");