CREATE OR REPLACE PROCEDURE "proc_create_role"(
  "p_id"          UUID,
  "p_name"        VARCHAR(255),
  "p_description" VARCHAR(255),
  "p_claims"      type_claim[]
)
LANGUAGE plpgsql
AS $$
BEGIN
  INSERT INTO "roles" (
    "id", 
    "name", 
    "description"
  ) VALUES (
    "p_id",
    "p_name",
    "p_description"
  );
  
  INSERT INTO "roles_claims" (
    "role_id", 
    "claim_id"
  ) 
  SELECT
    "p_id" as "role_id",
    pc."id" as "claim_id"
  FROM UNNEST("p_claims") as pc;
  
END;$$
