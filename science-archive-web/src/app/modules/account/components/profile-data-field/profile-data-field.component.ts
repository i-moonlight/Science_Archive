import { Component, Input } from "@angular/core";

@Component({
  selector: "app-profile-data-field",
  templateUrl: "./profile-data-field.component.html",
  styleUrls: ["./profile-data-field.component.scss"],
})
export class ProfileDataFieldComponent {
  @Input() name: string = "";
  @Input() value: string = "";
}
