-- Claims

CREATE TABLE IF NOT EXISTS "claims" (
  "id"          UUID         NOT NULL,
  "value"       VARCHAR(255) NOT NULL,
  "name"        VARCHAR(255)     NULL,
  "description" VARCHAR(255)     NULL,
  
  PRIMARY KEY ("id")
);

CREATE INDEX IF NOT EXISTS "idx__claims__value"
  ON "claims" ("value");