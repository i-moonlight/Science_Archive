-- Relation between categories with each other

CREATE TABLE IF NOT EXISTS "categories_subcategories" (
  "category_id"     UUID NOT NULL,
  "subcategory_id"  UUID NOT NULL,
  
  PRIMARY KEY ("category_id", "subcategory_id"),
  
  CONSTRAINT "idx__categories_subcategories__category_id__categories__id"
    FOREIGN KEY ("category_id")
    REFERENCES "categories" ("id"),

  CONSTRAINT "idx__categories_subcategories__subcategory_id__categories__id"
    FOREIGN KEY ("subcategory_id")
    REFERENCES "categories" ("id")
);