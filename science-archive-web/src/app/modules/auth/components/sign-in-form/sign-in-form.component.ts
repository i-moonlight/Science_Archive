import { Component, EventEmitter, Output } from "@angular/core";
import { SignInRequest } from "@models/auth/requests/sign-in.request";
import { AuthService } from "@services/auth.service";
import { LocalStorageService } from "@services/local-storage.service";

@Component({
  selector: "app-sign-in-form",
  templateUrl: "./sign-in-form.component.html",
  styleUrls: ["./sign-in-form.component.scss"],
})
export class SignInFormComponent {
  login: string = "";
  password: string = "";

  @Output() onChangeForm = new EventEmitter<string>();

  constructor(private authService: AuthService, private storageService: LocalStorageService) {}

  onChangeAuthType(): void {
    this.onChangeForm.next("sign-up");
  }

  async onSignIn() {
    const request: SignInRequest = {
      login: this.login,
      password: this.password,
    };

    this.authService.signIn(request).subscribe({
      next: (response) => {
        if (!response.success) {
          alert(response.error);
          return;
        }

        if (!response.data) {
          console.error("Cannot get valid auth token from server!");
          return;
        }

        this.storageService.saveToken(response.data.token);
        this.storageService.saveLogin(response.data.user.login);
        window.location.href = "/main";
      },
    });
  }
}
