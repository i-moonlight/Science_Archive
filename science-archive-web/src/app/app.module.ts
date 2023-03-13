import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthComponent } from './pages/auth/auth.component';
import { MainComponent } from './pages/main/main.component';
import { SignInFormComponent } from './components/auth/sign-in-form/sign-in-form.component';
import { SignUpFormComponent } from './components/auth/sign-up-form/sign-up-form.component';

@NgModule({
  declarations: [
    AppComponent,
    AuthComponent,
    MainComponent,
    SignInFormComponent,
    SignUpFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
