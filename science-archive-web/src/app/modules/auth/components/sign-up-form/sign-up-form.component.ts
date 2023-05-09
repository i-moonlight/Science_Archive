import { Component, EventEmitter, Output } from "@angular/core";

import { SignUpRequest } from "@models/operations/auth/requests/sign-up.request";
import { AuthService } from "@services/auth.service";

@Component({
  selector: "app-sign-up-form",
  templateUrl: "./sign-up-form.component.html",
  styleUrls: ["./sign-up-form.component.scss"],
})
export class SignUpFormComponent {
  name: string = "";
  email: string = "";
  login: string = "";
  password: string = "";
  repeatPassword: string = "";

  @Output() onChangeForm = new EventEmitter<string>();

  constructor(private authService: AuthService) {}

  changeAuthType() {
    this.onChangeForm.next("sign-in");
  }

  async onSignUp() {
    const request: SignUpRequest = {
      user: {
        name: this.name,
        email: this.email,
        login: this.login,
      },
      password: this.password,
    };

    this.authService.signUp(request).subscribe({
      next: (response) => {
        if (response.success) {
          alert("You have successfully signed up!");
          this.changeAuthType();
        } else {
          alert(response.error);
        }
      },
      error: (error) => {
        alert(error);
      },
    });
  }
}
