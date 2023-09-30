import { Component, Input } from "@angular/core";
import { Article } from "@models/article/article";

@Component({
  selector: "app-my-article-card",
  templateUrl: "./my-article-card.component.html",
  styleUrls: ["./my-article-card.component.scss"],
})
export class MyArticleCardComponent {
  @Input() article: Article | null = null;
}
