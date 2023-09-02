import { Component, Input } from "@angular/core";
import { AuthorUser } from "@models/user/author-user";
import { Article } from "@models/article/article";

@Component({
  selector: "app-author-card",
  templateUrl: "./author-card.component.html",
  styleUrls: ["./author-card.component.scss"],
})
export class AuthorCardComponent {
  @Input() authorUser: AuthorUser | null = null;
  articles: Article[] = [];
  isArticlesShown: boolean = false;

  toggleShowArticles() {
    this.isArticlesShown = !this.isArticlesShown;
  }
}
