DROP FUNCTION "func_get_all_authors";

CREATE OR REPLACE FUNCTION "func_get_all_authors" ()
RETURNS TABLE
(
  "id"          UUID,
  "name"        VARCHAR(100),
  "articlesIds" UUID[]
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
    SELECT
      u."id",
      u."name",
      array_agg(av."article_id") as "articlesIds"
    FROM "users"                          AS u
      INNER JOIN "articles_authors"       AS aa ON aa."author_id"  = u."id"
      INNER JOIN "articles_verification"  AS av ON av."article_id" = aa."article_id"
    WHERE av."status" = 1
    GROUP BY u."id";
END;$$