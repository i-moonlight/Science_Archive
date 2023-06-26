-- Users to roles junction table

CREATE TABLE IF NOT EXISTS "users_roles" (
  "user_id" UUID NOT NULL,
  "role_id" UUID NOT NULL,

  PRIMARY KEY ("user_id", "role_id"),

  CONSTRAINT "idx__users_roles__user_id__users__id"
    FOREIGN KEY ("user_id")
    REFERENCES "users" ("id"),

  CONSTRAINT "idx__users_roles__role_id__roles__id"
    FOREIGN KEY ("role_id")
    REFERENCES "roles" ("id")
);