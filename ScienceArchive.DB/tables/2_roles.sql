-- Roles

CREATE TABLE IF NOT EXISTS "roles" (
  "id"          UUID         NOT NULL,
  "name"        VARCHAR(255) NOT NULL,
  "description" VARCHAR(255)     NULL,

  PRIMARY KEY ("id")
);

CREATE INDEX IF NOT EXISTS "idx__roles__name"
  ON "roles" ("name");