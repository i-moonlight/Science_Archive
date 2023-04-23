import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthComponent } from './pages/auth-page/auth-page.component';
import { MainComponent } from './pages/main-page/main-page.component';

const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "main" },
  { path: "auth", component: AuthComponent },
  { path: "main", component: MainComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
