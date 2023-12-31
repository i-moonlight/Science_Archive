import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import SharedModule from "@modules/shared/shared.module";
import { NewsPageComponent } from "@modules/news/pages/news-page/news-page.component";
import { NewsCardComponent } from "@modules/news/components/news-card/news-card.component";
import { NewsDetailsPageComponent } from "@modules/news/pages/news-details-page/news-details-page.component";
import { NewsCardLoadingComponent } from './components/news-card-loading/news-card-loading.component';

@NgModule({
  imports: [CommonModule, SharedModule],
  declarations: [NewsPageComponent, NewsDetailsPageComponent, NewsCardComponent, NewsCardLoadingComponent],
})
export class NewsModule {}
