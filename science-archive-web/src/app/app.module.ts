import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { AuthRequestInterceptor } from "@helpers/auth-request.interceptor";

import { AccountPageComponent } from "@pages/account-page/account-page.component";
import { AuthPageComponent } from "@pages/auth-page/auth-page.component";
import { MainPageComponent } from "@pages/main-page/main-page.component";

import SharedModule from "@modules/shared/shared.module";
import AuthModule from "@modules/auth/auth.module";
import MainModule from "@modules/main/main.module";

import { AppComponent } from "./app.component";
import { AppRoutingModule } from "./app-routing.module";

@NgModule({
  imports: [BrowserModule, AppRoutingModule, HttpClientModule, AuthModule, MainModule, SharedModule],
  declarations: [AppComponent, AccountPageComponent, AuthPageComponent, MainPageComponent],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: AuthRequestInterceptor, multi: true }],
  bootstrap: [AppComponent],
})
export class AppModule {}
