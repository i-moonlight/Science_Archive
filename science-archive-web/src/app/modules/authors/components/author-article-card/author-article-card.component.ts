import { Component, Input } from "@angular/core";
import { Article } from "@models/article/article";

@Component({
  selector: "app-author-article-card",
  templateUrl: "./author-article-card.component.html",
  styleUrls: ["./author-article-card.component.scss"],
})
export class AuthorArticleCardComponent {
  @Input() article: Article | null = null;
}
