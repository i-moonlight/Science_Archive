-- Roles to claims junction table

CREATE TABLE IF NOT EXISTS "roles_claims" (
  "role_id"  UUID NOT NULL,
  "claim_id" UUID NOT NULL,
  
  PRIMARY KEY ("role_id", "claim_id"),
  
  CONSTRAINT "idx__roles_claims__role_id__roles_id"
    FOREIGN KEY ("role_id")
    REFERENCES "roles" ("id"),
  
  CONSTRAINT "idx__roles_claims__claim_id__claims_id"
    FOREIGN KEY ("claim_id")
    REFERENCES "claims" ("id")
);