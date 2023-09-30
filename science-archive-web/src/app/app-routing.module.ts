import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AuthPageComponent } from "@pages/auth-page/auth-page.component";
import { MainPageComponent } from "@pages/main-page/main-page.component";
import { ArticlesPageComponent } from "@modules/articles/pages/articles-page/articles-page.component";
import { AuthorsPageComponent } from "@modules/authors/pages/authors-page/authors-page.component";
import { CategoriesPageComponent } from "@modules/categories/pages/categories-page/categories-page.component";
import { NewsPageComponent } from "@modules/news/pages/news-page/news-page.component";
import { NewsDetailsPageComponent } from "@modules/news/pages/news-details-page/news-details-page.component";
import { ArticleDetailsPageComponent } from "@modules/articles/pages/article-details-page/article-details-page.component";
import { AccountPageComponent } from "@pages/account-page/account-page.component";
import { isAuthorizedGuard } from "./guards/auth.guard";
import { ProfilePageComponent } from "@modules/account/pages/profile-page/profile-page.component";
import { MyArticlesPageComponent } from "@modules/account/pages/my-articles-page/my-articles-page.component";

const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "main" },
  { path: "auth", component: AuthPageComponent },
  {
    path: "account",
    component: AccountPageComponent,
    canActivate: [isAuthorizedGuard],
    children: [
      { path: "", pathMatch: "full", redirectTo: "profile" },
      { path: "profile", component: ProfilePageComponent },
      { path: "articles", component: MyArticlesPageComponent },
    ],
  },
  {
    path: "main",
    component: MainPageComponent,
    children: [
      { path: "", pathMatch: "full", redirectTo: "articles" },
      {
        path: "articles",
        component: ArticlesPageComponent,
      },
      {
        path: "authors",
        component: AuthorsPageComponent,
      },
      {
        path: "categories",
        component: CategoriesPageComponent,
      },
      {
        path: "news",
        component: NewsPageComponent,
      },
      {
        path: "articles/:id",
        component: ArticleDetailsPageComponent,
      },
      {
        path: "news/:id",
        component: NewsDetailsPageComponent,
      },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
