import { Component, OnInit } from "@angular/core";
import { Article } from "@models/article/article";
import { LocalStorageService } from "@services/local-storage.service";
import { ArticleService } from "@services/article.service";
import { Router } from "@angular/router";
import { Category } from "@models/category/category";
import { CategoryService } from "@services/category.service";

@Component({
  selector: "app-my-articles-page",
  templateUrl: "./my-articles-page.component.html",
  styleUrls: ["./my-articles-page.component.scss"],
})
export class MyArticlesPageComponent implements OnInit {
  isLoading = true;
  showEditModal = false;
  articles: Article[] = [];
  categories: Category[] = [];
  createNew = false;

  currentArticle!: Article;
  selectedCategory: Category | null = null;

  constructor(
    private router: Router,
    private localStorageService: LocalStorageService,
    private articleService: ArticleService,
    private categoryService: CategoryService
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

    this.categoryService.getAllCategories().subscribe({
      next: (response) => (this.categories = response.categories),
      error: (err) => alert(err),
    });

    this.currentArticle = {
      title: "",
      description: "",
      authorsIds: [currentUser.id],
      status: 0,
      categoryId: "",
      documentsPaths: [],
    };
  }

  onCreateClick() {
    this.showEditModal = true;
    this.createNew = true;
  }

  onEditModalClose() {
    this.showEditModal = false;
    this.createNew = false;
  }

  onSaveClick() {
    console.log(this.currentArticle);
    this.articleService.createArticle(this.currentArticle).subscribe({
      next: () => (this.showEditModal = false),
      error: (err) => alert(err),
    });
  }
}
