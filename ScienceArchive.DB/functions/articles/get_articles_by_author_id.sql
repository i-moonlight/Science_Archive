CREATE OR REPLACE FUNCTION "func_get_articles_by_author_id" (
  "p_author_id" UUID
)
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
      CASE WHEN length(a."description") > 700 THEN concat(left(a."description", 700), '...') ELSE a."description" END AS "body",
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
     INNER JOIN "articles_creation"   AS acr ON acr."article_id" = a."id"
     INNER JOIN "articles_authors"    AS aa  ON aa."article_id" = a."id" and aa."author_id" = "p_author_id";
END;$$