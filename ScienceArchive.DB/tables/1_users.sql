-- Users main data

CREATE TABLE IF NOT EXISTS "users" (
  "id" UUID NOT NULL,
  "name" VARCHAR(100) NOT NULL,
  "email" VARCHAR(50) NOT NULL,
  PRIMARY KEY ("id")
);

CREATE INDEX IF NOT EXISTS "idx_users_email"
ON "users" ("email");