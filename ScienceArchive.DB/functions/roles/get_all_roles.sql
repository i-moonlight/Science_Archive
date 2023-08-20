CREATE OR REPLACE FUNCTION "func_get_all_roles" ()
RETURNS TABLE (
  "id"           UUID,
  "name"         VARCHAR(255),
  "description"  VARCHAR(255),
  "claimsIds"    UUID[]
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
    SELECT
      r."id",
      r."name",
      r."description",
      (
        SELECT
          array_agg(rc.claim_id)
        FROM "roles_claims"   AS rc
        WHERE rc."role_id" = r."id"
      ) as "claimsIds"
    FROM "roles" AS r;
END;$$