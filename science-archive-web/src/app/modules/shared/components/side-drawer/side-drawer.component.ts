import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: "app-side-drawer",
  templateUrl: "./side-drawer.component.html",
  styleUrls: ["./side-drawer.component.scss"],
})
export class SideDrawerComponent {
  @Input() title: string = "";
  @Input() isOpen: boolean = false;
  @Output() onClose = new EventEmitter();

  onInternalClose() {
    this.isOpen = false;
    this.onClose.emit();
  }
}
