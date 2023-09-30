import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import SharedModule from "@modules/shared/shared.module";
import { CategoriesPageComponent } from "@modules/categories/pages/categories-page/categories-page.component";
import { CategoryCardComponent } from "@modules/categories/components/category-card/category-card.component";
import { SubcategoryCardComponent } from "@modules/categories/components/subcategory-card/subcategory-card.component";
import { CategoryCardLoadingComponent } from './components/category-card-loading/category-card-loading.component';

@NgModule({
  imports: [CommonModule, SharedModule],
  declarations: [CategoriesPageComponent, CategoryCardComponent, SubcategoryCardComponent, CategoryCardLoadingComponent],
})
export class CategoriesModule {}
