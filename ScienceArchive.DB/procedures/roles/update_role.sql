CREATE OR REPLACE PROCEDURE "proc_update_role" (
  "p_id"          UUID,
  "p_name"        VARCHAR(255),
  "p_description" VARCHAR(255),
  "p_claims"      type_claim[]
)
LANGUAGE plpgsql
AS $$
BEGIN 
  UPDATE "roles" as r 
  SET 
    "name"        = COALESCE("p_name", r."name"),
    "description" = COALESCE("p_description", r."description")
  WHERE r."id" = "p_id";
  
  DELETE FROM "roles_claims"
  WHERE "role_id" = "p_id";
  
  INSERT INTO "roles_claims" (
    role_id, 
    claim_id
  )
  SELECT
    "p_id" as "role_id",
    pc."id" as "claim_id"
  FROM UNNEST("p_claims") as pc;
    
END;$$