CREATE OR REPLACE FUNCTION "func_get_all_authors" ()
RETURNS TABLE
(
  "id"       UUID,
  "name"     VARCHAR(100),
  "articlesIds" UUID[]
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
    SELECT
      u."id",
      u."name",
      array_agg(aa."article_id") as "articlesIds"
    FROM "users"                   AS u
     INNER JOIN "articles_authors" AS aa ON aa."author_id" = u."id"
    GROUP BY u."id";
END;$$