import { Subcategory } from "@models/category/subcategory";

export interface Category {
  id: string;
  name: string;
  subcategories: Subcategory[];
}
