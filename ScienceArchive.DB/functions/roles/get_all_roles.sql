CREATE OR REPLACE FUNCTION "func_get_all_roles" ()
RETURNS TABLE (
  "id"           UUID,
  "name"         VARCHAR(255),
  "description"  VARCHAR(255),
  "claims"       type_claim[]
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
  SELECT
    r."id",
    r."name",
    r."description",
    ARRAY_AGG(c)
  FROM "roles"                AS r
    INNER JOIN "roles_claims" AS rc ON r."id" = rc."role_id"
    INNER JOIN "claims"       AS c  ON c."id" = rc."claim_id"
  GROUP BY r."id";
END;$$