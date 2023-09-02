import { NgModule } from "@angular/core";
import { ErrorBannerComponent } from "./components/error-banner/error-banner.component";
import { CommonModule } from "@angular/common";
import { ReadMoreButtonComponent } from "./components/read-more-button/read-more-button.component";
import { SideDrawerComponent } from "./components/side-drawer/side-drawer.component";

@NgModule({
  imports: [CommonModule],
  declarations: [ErrorBannerComponent, ReadMoreButtonComponent, SideDrawerComponent],
  exports: [ErrorBannerComponent, CommonModule, ReadMoreButtonComponent, SideDrawerComponent],
})
export default class SharedModule {}
