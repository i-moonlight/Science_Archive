-- Articles

CREATE TABLE IF NOT EXISTS "articles" (
  "id"          UUID         NOT NULL,
  "title"       VARCHAR(255) NOT NULL,
  "description" TEXT             NULL,
  
  PRIMARY KEY ("id")
);

CREATE INDEX IF NOT EXISTS idx_users_auth_login
  ON "users_auth" ("login");
