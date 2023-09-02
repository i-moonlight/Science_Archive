import { Component, OnInit } from "@angular/core";
import { Category } from "@models/category/category";
import { CategoryService } from "@services/category.service";

@Component({
  selector: "app-categories-page",
  templateUrl: "./categories-page.component.html",
  styleUrls: ["./categories-page.component.scss"],
})
export class CategoriesPageComponent implements OnInit {
  categories: Category[] = [];
  isLoading: boolean = true;

  constructor(private readonly categoryService: CategoryService) {}

  ngOnInit() {
    this.categoryService.getAllArticles().subscribe({
      next: (response) => {
        this.isLoading = false;
        if (!response.success) {
          alert(response.error);
          return;
        }

        if (!response.data) {
          alert("Cannot get any data!");
          return;
        }

        this.categories = response.data!.categories;
      },
    });
  }
}
