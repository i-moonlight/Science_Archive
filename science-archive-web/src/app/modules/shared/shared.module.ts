import { NgModule } from "@angular/core";
import { ErrorBannerComponent } from "./components/error-banner/error-banner.component";
import { CommonModule } from "@angular/common";

@NgModule({
  imports: [CommonModule],
  declarations: [ErrorBannerComponent],
  exports: [ErrorBannerComponent, CommonModule],
})
export default class SharedModule {}
