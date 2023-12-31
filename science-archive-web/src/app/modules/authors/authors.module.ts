import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import SharedModule from "@modules/shared/shared.module";
import { AuthorsPageComponent } from "@modules/authors/pages/authors-page/authors-page.component";
import { AuthorCardComponent } from "@modules/authors/components/author-card/author-card.component";
import { AuthorArticleCardComponent } from "@modules/authors/components/author-article-card/author-article-card.component";
import { AuthorCardLoadingComponent } from './components/author-card-loading/author-card-loading.component';

@NgModule({
  imports: [CommonModule, SharedModule],
  declarations: [AuthorsPageComponent, AuthorCardComponent, AuthorArticleCardComponent, AuthorCardLoadingComponent],
})
export class AuthorsModule {}
