CREATE OR REPLACE FUNCTION "func_get_claims_by_user_id" (
  "p_user_id" UUID
)
RETURNS TABLE (
  "id"           UUID,
  "name"         VARCHAR(255),
  "description"  VARCHAR(255),
  "value"        VARCHAR(255)
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
  SELECT DISTINCT
    c."id",
    c."name",
    c."description",
    c.value
  FROM users_roles AS ur
    JOIN roles_claims AS rc ON rc.role_id = ur.role_id
    JOIN claims AS c on c.id = rc.claim_id
  WHERE ur."user_id" = "p_user_id";
END;$$