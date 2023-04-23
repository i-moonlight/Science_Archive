import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { AuthComponent } from "./pages/auth-page/auth-page.component";
import { MainComponent } from "./pages/main-page/main-page.component";
import { SignInFormComponent } from "./components/auth-page/sign-in-form/sign-in-form.component";
import { SignUpFormComponent } from "./components/auth-page/sign-up-form/sign-up-form.component";
import { FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { AuthRequestInterceptor } from "./helpers/auth-request.interceptor";
import { AccountPageComponent } from "./pages/account-page/account-page.component";
import { AllArticlesPageComponent } from "./pages/articles/all-articles-page/all-articles-page.component";
import { AllAuthorsPageComponent } from "./pages/authors/all-authors-page/all-authors-page.component";
import { ArticlePageComponent } from "./pages/articles/article-page/article-page.component";
import { AuthorPageComponent } from "./pages/authors/author-page/author-page.component";
import { ErrorBannerComponent } from './components/shared/error-banner/error-banner.component';

@NgModule({
  declarations: [
    AppComponent,

    AuthComponent,
    SignInFormComponent,
    SignUpFormComponent,

    MainComponent,
    AccountPageComponent,
    ArticlePageComponent,
    AuthorPageComponent,
    AllArticlesPageComponent,
    AllAuthorsPageComponent,
    ErrorBannerComponent,
  ],
  imports: [BrowserModule, AppRoutingModule, FormsModule, HttpClientModule],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthRequestInterceptor, multi: true }],
  bootstrap: [AppComponent],
})
export class AppModule {}
