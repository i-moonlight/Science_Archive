import { Component, Input } from "@angular/core";

@Component({
  selector: "app-error-banner",
  templateUrl: "./error-banner.component.html",
  styleUrls: ["./error-banner.component.scss"],
})
export class ErrorBannerComponent {
  @Input() innerText: string;

  constructor() {
    this.innerText = "";
  }
}
