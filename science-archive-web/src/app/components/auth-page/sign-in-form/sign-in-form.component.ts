import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { SignInRequest } from 'src/app/models/requests/sign-in.request';
import { AuthService } from 'src/app/services/auth.service';
import { LocalStorageService } from 'src/app/services/local-storage.service';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.scss']
})
export class SignInFormComponent {
  login: string = "";
  password: string = "";

  @Output() onChangeForm = new EventEmitter<string>();

  constructor(
    private authService: AuthService,
    private storageService: LocalStorageService,
    private router: Router
  ) {}

  changeAuthType(): void {
    this.onChangeForm.next("sign-up");
  }

  async onSignIn() {
    const request: SignInRequest = {
      login: this.login,
      password: this.password
    };

    this.authService
      .signin(request)
      .subscribe({
        next: (response) => {
          if (response.success) {
            if (!response.data) {
              console.error("Cannot get valid auth token from server!");
              return;
            }

            this.storageService.saveToken(response.data.token);
            this.storageService.saveLogin(this.login);
            this.router.navigate(['main']);
          } else {
            alert(response.error);
          }
        }
      });
  }
}
