import { Component, OnInit } from "@angular/core";
import { Article } from "@models/article/article";
import { ArticleService } from "@services/article.service";
import { ActivatedRoute } from "@angular/router";
import { Subcategory } from "@models/category/subcategory";

@Component({
  selector: "app-articles-page",
  templateUrl: "./articles-page.component.html",
  styleUrls: ["./articles-page.component.scss"],
})
export class ArticlesPageComponent implements OnInit {
  articles: Article[] = [];
  category: Subcategory | null = null;
  isLoading: boolean = true;

  constructor(private readonly articleService: ArticleService, private readonly route: ActivatedRoute) {}

  ngOnInit() {
    this.route.queryParams.subscribe((params) => {
      const categoryId = params["categoryId"] as string;

      if (!categoryId) {
        this.category = null;
        this.getAllArticles();
      } else {
        this.getArticlesByCategoryId(categoryId);
      }
    });
  }

  private getAllArticles() {
    this.articleService.getAllArticles().subscribe({
      complete: () => (this.isLoading = false),
      next: (response) => (this.articles = response.articles),
      error: (err) => alert(err.message),
    });
  }

  private getArticlesByCategoryId(categoryId: string) {
    console.log(this.category);
    this.articleService.getArticlesByCategoryId(categoryId).subscribe({
      complete: () => (this.isLoading = false),
      next: (response) => {
        this.articles = response.articles;
        this.category = response.category;
      },
      error: (err) => alert(err.message),
    });
  }
}
