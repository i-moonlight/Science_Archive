import { Component, Input } from "@angular/core";
import { Subcategory } from "@models/category/subcategory";
import { Router } from "@angular/router";

@Component({
  selector: "app-subcategory-card",
  templateUrl: "./subcategory-card.component.html",
  styleUrls: ["./subcategory-card.component.scss"],
})
export class SubcategoryCardComponent {
  @Input() subcategory: Subcategory | null = null;

  constructor(private readonly router: Router) {}

  async onClick() {
    const queryParams = {
      categoryId: this.subcategory!.id,
    };
    await this.router.navigate(["/main/articles"], { queryParams });
  }
}
