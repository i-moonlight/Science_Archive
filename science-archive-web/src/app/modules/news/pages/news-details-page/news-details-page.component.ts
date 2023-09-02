import { Component, OnInit } from "@angular/core";
import { News } from "@models/news/news";
import { ActivatedRoute } from "@angular/router";
import { NewsService } from "@services/news.service";

@Component({
  selector: "app-news-details-page",
  templateUrl: "./news-details-page.component.html",
  styleUrls: ["./news-details-page.component.scss"],
})
export class NewsDetailsPageComponent implements OnInit {
  news: News | null = null;

  constructor(private route: ActivatedRoute, private newsService: NewsService) {}

  ngOnInit(): void {
    const newsId = this.route.snapshot.paramMap.get("id");

    if (!newsId) {
      alert("Invalid news ID!");
      return;
    }

    this.newsService.getNewsById(newsId).subscribe({
      next: (response) => {
        if (!response.success) {
          alert(response.error);
          return;
        }

        if (!response.data) {
          alert("Cannot get any data!");
          return;
        }

        this.news = response.data!.news;
      },
    });
  }
}
