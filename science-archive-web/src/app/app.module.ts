import { NgModule, isDevMode } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { AuthRequestInterceptor } from "@middleware/auth-request.interceptor";

import { AccountPageComponent } from "@pages/account-page/account-page.component";
import { AuthPageComponent } from "@pages/auth-page/auth-page.component";
import { MainPageComponent } from "@pages/main-page/main-page.component";

import SharedModule from "@modules/shared/shared.module";
import AuthModule from "@modules/auth/auth.module";

import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";
import { ArticlesModule } from "@modules/articles/articles.module";
import { AuthorsModule } from "@modules/authors/authors.module";
import { CategoriesModule } from "@modules/categories/categories.module";
import { NewsModule } from "@modules/news/news.module";
import { AdminPageComponent } from "@pages/admin-page/admin-page.component";
import { NgOptimizedImage } from "@angular/common";
import { ServiceWorkerModule } from "@angular/service-worker";
import { environment } from "@environments/environment";
import { AccountModule } from "@modules/account/account.module";

@NgModule({
  imports: [
    // Built-in modules
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgOptimizedImage,

    // Other modules
    SharedModule,
    AuthModule,
    AccountModule,
    ArticlesModule,
    AuthorsModule,
    CategoriesModule,
    NewsModule,
    ServiceWorkerModule.register("ngsw-worker.js", {
      enabled: environment.production,
      registrationStrategy: "registerWhenStable:30000",
    }),
    ServiceWorkerModule.register("ngsw-worker.js", {
      enabled: !isDevMode(),
      registrationStrategy: "registerWhenStable:30000",
    }),
  ],
  declarations: [AppComponent, AccountPageComponent, AuthPageComponent, MainPageComponent, AdminPageComponent],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthRequestInterceptor, multi: true }],
  bootstrap: [AppComponent],
})
export class AppModule {}
