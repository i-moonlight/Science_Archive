import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-sign-in-form',
  templateUrl: './sign-in-form.component.html',
  styleUrls: ['./sign-in-form.component.scss']
})
export class SignInFormComponent {
  @Output() onChangeForm = new EventEmitter<string>();

  changeAuthType(): void {
    this.onChangeForm.next("sign-up");
  }
}
