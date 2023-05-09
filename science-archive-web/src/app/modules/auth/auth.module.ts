import { NgModule } from "@angular/core";

import { SignInFormComponent } from "./components/sign-in-form/sign-in-form.component";
import { SignUpFormComponent } from "./components/sign-up-form/sign-up-form.component";
import { FormsModule } from "@angular/forms";

@NgModule({
  imports: [FormsModule],
  declarations: [SignInFormComponent, SignUpFormComponent],
  exports: [SignInFormComponent, SignUpFormComponent],
})
export default class AuthModule {}
