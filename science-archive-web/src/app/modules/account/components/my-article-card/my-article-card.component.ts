import { Component, Input } from "@angular/core";
import { Article } from "@models/article/article";
import { Router } from "@angular/router";

@Component({
  selector: "app-my-article-card",
  templateUrl: "./my-article-card.component.html",
  styleUrls: ["./my-article-card.component.scss"],
})
export class MyArticleCardComponent {
  @Input() article!: Article;

  constructor(private readonly router: Router) {}

  async onCardClick() {
    // TODO Create logic for card click
  }
}
