-- Subcategories

CREATE TABLE IF NOT EXISTS "subcategories" (
  "id"           UUID          NOT NULL,
  "name"         VARCHAR(255)  NOT NULL,
  "category_id"  UUID          NOT NULL,
  
  PRIMARY KEY ("id"),

  CONSTRAINT "idx__subcategories__category_id__categories__id"
    FOREIGN KEY ("category_id")
    REFERENCES "categories" ("id")
);