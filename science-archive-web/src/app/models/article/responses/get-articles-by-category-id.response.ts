import { Article } from "@models/article/article";
import { Subcategory } from "@models/category/subcategory";

export interface GetArticlesByCategoryIdResponse {
  articles: Article[];
  category: Subcategory;
}
