import { Component, EventEmitter, Output } from '@angular/core';

@Component({
  selector: 'app-sign-up-form',
  templateUrl: './sign-up-form.component.html',
  styleUrls: ['./sign-up-form.component.scss']
})
export class SignUpFormComponent {
  @Output() onChangeForm = new EventEmitter<string>();

  changeAuthType() {
    this.onChangeForm.next("sign-in");
  }
}
