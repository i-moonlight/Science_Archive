import { Component, Input } from "@angular/core";
import { News } from "@models/news/news";

@Component({
  selector: "app-admin-news-card",
  templateUrl: "./admin-news-card.component.html",
  styleUrls: ["./admin-news-card.component.scss"],
})
export class AdminNewsCardComponent {
  @Input() news!: News;
}
