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
        this.storageService.saveToken(response.token);
        this.storageService.saveCurrentUser(response.user);
        window.location.href = "/main";
      },
    });
  }
}
