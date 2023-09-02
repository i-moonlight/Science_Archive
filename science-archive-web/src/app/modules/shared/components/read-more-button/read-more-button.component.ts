import { Component, Input } from "@angular/core";
import { Router } from "@angular/router";

@Component({
  selector: "app-read-more-button",
  templateUrl: "./read-more-button.component.html",
  styleUrls: ["./read-more-button.component.scss"],
})
export class ReadMoreButtonComponent {
  @Input() title = "Read more";
  @Input() onClick: (() => void) | null = null;
  @Input() routerLink: string | null = null;

  constructor(private router: Router) {}

  onInternalClick() {
    if (this.onClick) {
      this.onClick();
    }

    if (this.routerLink) {
      this.router.navigate([this.routerLink]);
    }
  }
}
