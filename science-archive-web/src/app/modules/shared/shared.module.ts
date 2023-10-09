import { NgModule } from "@angular/core";
import { ErrorBannerComponent } from "./components/error-banner/error-banner.component";
import { CommonModule } from "@angular/common";
import { SideDrawerComponent } from "./components/side-drawer/side-drawer.component";
import { ModalWindowComponent } from "./components/modal-window/modal-window.component";
import { ActionButtonComponent } from "@modules/shared/components/action-button/action-button.component";

@NgModule({
  imports: [CommonModule],
  declarations: [ErrorBannerComponent, ActionButtonComponent, SideDrawerComponent, ModalWindowComponent],
  exports: [ErrorBannerComponent, CommonModule, ActionButtonComponent, SideDrawerComponent, ModalWindowComponent],
})
export default class SharedModule {}
