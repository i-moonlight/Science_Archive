import { Component } from '@angular/core';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.scss']
})
export class AuthComponent {
  isSignIn: boolean;
  isSignUp: boolean;

  constructor() {
    this.isSignIn = false;
    this.isSignUp = true;
  }

  public changeAuthType(value: string): void {
    this.isSignIn = value === "sign-in";
    this.isSignUp = value === "sign-up";
  }
}
