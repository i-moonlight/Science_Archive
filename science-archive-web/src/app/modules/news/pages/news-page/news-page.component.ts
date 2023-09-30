import { Component, OnInit } from "@angular/core";
import { News } from "@models/news/news";
import { NewsService } from "@services/news.service";

@Component({
  selector: "app-news-page",
  templateUrl: "./news-page.component.html",
  styleUrls: ["./news-page.component.scss"],
})
export class NewsPageComponent implements OnInit {
  news: News[] = [];
  isLoading: boolean = true;

  constructor(private readonly newsService: NewsService) {}

  ngOnInit(): void {
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
}
