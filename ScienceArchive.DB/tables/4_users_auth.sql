-- Users auth data

CREATE TABLE IF NOT EXISTS "users_auth" (
  "user_id"       UUID         NOT NULL,
  "login"         VARCHAR(30)  NOT NULL,
  "password"      VARCHAR(255) NOT NULL,
  "password_salt" VARCHAR(255) NOT NULL,
  
  PRIMARY KEY ("user_id"),
  
  CONSTRAINT "FK__users_auth__user_id__users__id"
    FOREIGN KEY ("user_id")
    REFERENCES "users" ("id")
);

CREATE INDEX IF NOT EXISTS idx__users_auth__login
  ON "users_auth" ("login");
