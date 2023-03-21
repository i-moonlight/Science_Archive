import { Component, EventEmitter, Input, Output } from '@angular/core';
import { SignUpRequest } from 'src/app/models/requests/sign-up.request';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.scss']
})
export class SignUpFormComponent {
  name: string = '';
  email: string = '';
  login: string = '';
  password: string = '';
  repeatPassword: string = '';

  @Output() onChangeForm = new EventEmitter<string>();

  constructor(private authService: AuthService) {}

  changeAuthType() {
    this.onChangeForm.next("sign-in");
  }

  async onSignUp() {
    const request: SignUpRequest = {
      name: this.name,
      email: this.email,
      login: this.login,
      password: this.password
    };

    this.authService
      .signup(request)
      .subscribe({
        next: (response) => {
          if (response.success) {
            alert("You have successfully signed up!");
          } else {
            alert("Something is wrong!")
          }
        },
        error: (error) => {
          alert(error);
        }
      });
  }
}
