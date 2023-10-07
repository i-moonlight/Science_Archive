import { Component, Input, OnInit } from "@angular/core";
import { Article } from "@models/article/article";

@Component({
  selector: "app-article-card",
  templateUrl: "./article-card.component.html",
  styleUrls: ["./article-card.component.scss"],
})
export class ArticleCardComponent implements OnInit {
  @Input() article!: Article;

  ngOnInit(): void {
    this.article.description = this.article.description?.replace("\n", "<br>") ?? null;
  }
}
