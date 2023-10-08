import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { ProfilePageComponent } from "./pages/profile-page/profile-page.component";
import { MyArticlesPageComponent } from "./pages/my-articles-page/my-articles-page.component";
import { ProfileDataFieldComponent } from "./components/profile-data-field/profile-data-field.component";
import { MyArticleCardComponent } from "./components/my-article-card/my-article-card.component";
import SharedModule from "@modules/shared/shared.module";

@NgModule({
  imports: [CommonModule, SharedModule],
  declarations: [ProfilePageComponent, MyArticlesPageComponent, ProfileDataFieldComponent, MyArticleCardComponent],
})
export class AccountModule {}
