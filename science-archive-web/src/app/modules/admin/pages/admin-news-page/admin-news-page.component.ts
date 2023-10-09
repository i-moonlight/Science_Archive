import { Component, OnInit } from "@angular/core";
import { News } from "@models/news/news";
import { NewsService } from "@services/news.service";
import CreateNewsRequest from "@models/news/requests/create-news.request";
import { LocalStorageService } from "@services/local-storage.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-admin-news-page",
  templateUrl: "./admin-news-page.component.html",
  styleUrls: ["./admin-news-page.component.scss"],
})
export class AdminNewsPageComponent implements OnInit {
  news: News[] = [];
  isLoading = false;
  showModal = false;

  newNews!: News;

  constructor(
    private readonly newsService: NewsService,
    private readonly storageService: LocalStorageService,
    private readonly router: Router
  ) {
    const user = storageService.getCurrentUser();

    if (!user) {
      alert("This is only for authenticated users!");
      router.navigate(["main"]);
      return;
    }

    this.newNews = {
      title: "",
      body: "",
      authorId: user!.id,
      creationDate: new Date(),
    };
  }

  ngOnInit() {
    this.newsService.getAllNews().subscribe({
      complete: () => (this.isLoading = false),
      next: (response) => (this.news = this.processNews(response.news)),
      error: (err) => alert(err),
    });
  }

  private processNews(news: News[]): News[] {
    return news.map((singleNews) => {
      singleNews.creationDate = new Date(singleNews.creationDate.toString());
      return singleNews;
    });
  }

  onNewClick() {
    this.showModal = true;
  }

  onNewsCreate() {
    const dto: CreateNewsRequest = {
      news: this.newNews,
    };

    this.newsService.createNews(dto).subscribe({
      complete: () => (this.showModal = false),
      next: (response) => this.news.unshift(response.news),
      error: (err) => alert(err),
    });
  }
}
