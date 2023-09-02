CREATE OR REPLACE FUNCTION "func_create_role" (
  "p_id"           UUID,
  "p_name"         VARCHAR(255),
  "p_description"  VARCHAR(255),
  "p_claims_ids"   UUID[]
)
RETURNS TABLE
(
  "id"           UUID,
  "name"         VARCHAR(255),
  "description"  VARCHAR(255),
  "claimsIds"    UUID[]
)
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_create_role"(
    "p_id", 
    "p_name", 
    "p_description", 
    "p_claims_ids"
  );
  
  RETURN QUERY 
  SELECT * FROM "func_get_role_by_id"("p_id");
END;$$