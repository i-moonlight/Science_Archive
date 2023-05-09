import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { AuthPageComponent } from "@pages/auth-page/auth-page.component";
import { MainPageComponent } from "@pages/main-page/main-page.component";

const routes: Routes = [
  { path: "", pathMatch: "full", redirectTo: "main" },
  { path: "auth", component: AuthPageComponent },
  { path: "main", component: MainPageComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
