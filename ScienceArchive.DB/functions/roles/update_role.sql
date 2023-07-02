CREATE OR REPLACE FUNCTION "func_update_role" (
  "p_id"          UUID,
  "p_name"        VARCHAR(255),
  "p_description" VARCHAR(255),
  "p_claims"      type_claim[]
)
RETURNS TABLE (
  "id"           UUID,
  "name"         VARCHAR(255),
  "description"  VARCHAR(255),
  "claims"       type_claim[]
)
LANGUAGE plpgsql
AS $$
BEGIN
  CALL "proc_update_role" (
    "p_id",
    "p_name",
    "p_description",
    "p_claims"
  );

  RETURN QUERY
    SELECT
      r."id",
      r."name",
      r."description",
      ARRAY_AGG(c)
    FROM "roles"                AS r
      INNER JOIN "roles_claims" AS rc ON r."id" = rc."role_id"
      INNER JOIN "claims"       AS c  ON c."id" = rc."claim_id"
    WHERE r."id" = "p_id"
    GROUP BY r."id";
END;$$