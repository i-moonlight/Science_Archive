import { Component, OnInit } from "@angular/core";
import { Article } from "@models/article/article";
import { LocalStorageService } from "@services/local-storage.service";
import { ArticleService } from "@services/article.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-my-articles-page",
  templateUrl: "./my-articles-page.component.html",
  styleUrls: ["./my-articles-page.component.scss"],
})
export class MyArticlesPageComponent implements OnInit {
  isLoading = true;
  articles: Article[] = [];

  constructor(
    private router: Router,
    private localStorageService: LocalStorageService,
    private articleService: ArticleService
  ) {}

  ngOnInit(): void {
    const currentUser = this.localStorageService.getCurrentUser();

    if (!currentUser) {
      alert("This page is only for authorized users!");
      this.router.navigate(["main", "articles"]);
      return;
    }

    this.articleService.getMyArticles().subscribe({
      complete: () => (this.isLoading = false),
      next: (response) => (this.articles = response.articles),
      error: (err) => alert(err),
    });
  }
}
