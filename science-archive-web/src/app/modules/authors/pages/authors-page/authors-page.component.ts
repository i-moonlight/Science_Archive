import { Component, OnInit } from "@angular/core";
import { AuthorUser } from "@models/user/author-user";
import { UserService } from "@services/user.service";

@Component({
  selector: "app-authors-page",
  templateUrl: "./authors-page.component.html",
  styleUrls: ["./authors-page.component.scss"],
})
export class AuthorsPageComponent implements OnInit {
  authors: AuthorUser[] = [];
  isLoading: boolean = true;

  constructor(private readonly userService: UserService) {}

  ngOnInit() {
    this.userService.getAllAuthors().subscribe({
      complete: () => (this.isLoading = false),
      next: (response) => (this.authors = response.authors),
      error: (err) => alert(err),
    });
  }
}
