import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import SharedModule from "@modules/shared/shared.module";
import { ArticlesPageComponent } from "@modules/articles/pages/articles-page/articles-page.component";
import { ArticleCardComponent } from "@modules/articles/components/article-card/article-card.component";
import { ArticleDetailsPageComponent } from "./pages/article-details-page/article-details-page.component";

@NgModule({
  imports: [CommonModule, SharedModule],
  declarations: [ArticlesPageComponent, ArticleCardComponent, ArticleDetailsPageComponent],
})
export class ArticlesModule {}
