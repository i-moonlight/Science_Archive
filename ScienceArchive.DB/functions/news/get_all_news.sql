CREATE OR REPLACE FUNCTION "func_get_all_news" ()
RETURNS TABLE (
  "id"                UUID,
  "authorId"          UUID,
  "title"             VARCHAR(255),
  "body"              TEXT,
  "creationDate"      TIMESTAMP
)
LANGUAGE plpgsql
AS $$
BEGIN
  RETURN QUERY
  SELECT
    n."id",
    nc."author_id"         AS "authorId",
    n."title",
    CASE WHEN length(n."body") > 700 THEN concat(left(n."body", 700), '...') ELSE n."body" END AS "body",
    nc."created_timestamp" AS "creationDate"
  FROM "news"                  AS n
    INNER JOIN "news_creation" AS nc on n.id = nc.news_id
  ORDER BY nc."created_timestamp" DESC;
END;$$