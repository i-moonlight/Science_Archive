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
      next: (response) => {
        this.isLoading = false;
        if (!response.success) {
          alert(response.error);
          return;
        }

        if (!response.data) {
          alert("Cannot get any data!");
          return;
        }

        this.news = this.processNews(response.data!.news);
      },
    });
  }

  private processNews(news: News[]): News[] {
    return news.map((singleNews) => {
      singleNews.creationDate = new Date(singleNews.creationDate.toString());
      return singleNews;
    });
  }
}
