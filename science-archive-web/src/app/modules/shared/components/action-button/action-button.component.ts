import { Component, EventEmitter, Input, Output } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-action-button",
  templateUrl: "./action-button.component.html",
  styleUrls: ["./action-button.component.scss"],
})
export class ActionButtonComponent {
  @Input() title = "Read more";
  @Output() onClick = new EventEmitter();
  @Input() routerLink?: string;

  constructor(private router: Router) {}

  onInternalClick() {
    this.onClick.emit();

    if (this.routerLink) {
      this.router.navigate([this.routerLink]);
    }
  }
}
