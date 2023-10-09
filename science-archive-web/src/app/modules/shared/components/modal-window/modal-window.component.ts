import { Component, EventEmitter, Input, Output } from "@angular/core";

@Component({
  selector: "app-modal-window",
  templateUrl: "./modal-window.component.html",
  styleUrls: ["./modal-window.component.scss"],
})
export class ModalWindowComponent {
  @Input() isShown!: boolean;
  @Output() onClose = new EventEmitter<boolean>();

  onCloseClick() {
    this.onClose.emit(false);
  }
}
