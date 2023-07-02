CREATE OR REPLACE PROCEDURE "proc_update_news" (
  "p_id"    UUID,
  "p_title" VARCHAR(255),
  "p_body"  TEXT
)
LANGUAGE plpgsql
AS $$
BEGIN
  UPDATE "news" as n
  SET
    "title" = COALESCE("p_title", n."title"),
    "body"  = COALESCE("p_body", n."body")
  WHERE "id" = "p_id";
END;$$