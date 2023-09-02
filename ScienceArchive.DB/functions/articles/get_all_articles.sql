CREATE OR REPLACE FUNCTION "func_get_all_articles" ()
RETURNS TABLE (
  "id"                UUID,
  "categoryId"        UUID,
  "title"             VARCHAR(255),
  "description"       TEXT,
  "creationDate"      TIMESTAMP,
  "authorsIds"        UUID[],
  "documents"         JSONB
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
    SELECT
      a."id",
      ac."subcategory_id",
      a."title",
      a."description",
      acr."created_timestamp" AS "creationDate",
      (
        SELECT
          array_agg(ac."author_id")
        FROM "articles_authors" as ac
        WHERE ac."article_id" = a."id"
      ) AS "authorsIds",
      (
        SELECT
          jsonb_agg(
            json_build_object('document_path', ad."document_path")
          )
        FROM "articles_documents" AS ad
        WHERE ad."article_id" = a."id"
      ) AS "documents"
    FROM "articles" AS a
      INNER JOIN "articles_categories" AS ac  ON ac."article_id"  = a."id"
      INNER JOIN "articles_creation"   AS acr ON acr."article_id" = a."id";
END;$$