import { Component, OnInit } from "@angular/core";
import { IdentifiedUser } from "@models/user/identified-user";
import { UserService } from "@services/user.service";
import { LocalStorageService } from "@services/local-storage.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-profile-page",
  templateUrl: "./profile-page.component.html",
  styleUrls: ["./profile-page.component.scss"],
})
export class ProfilePageComponent implements OnInit {
  isLoading = true;
  userData!: IdentifiedUser;

  constructor(
    private router: Router,
    private localStorageService: LocalStorageService,
    private userService: UserService
  ) {}

  ngOnInit(): void {
    const currentUser = this.localStorageService.getCurrentUser();

    if (!currentUser) {
      alert("This page is only for authorized users!");
      this.router.navigate(["main", "articles"]);
      return;
    }

    this.userService.getUserById(currentUser.id).subscribe({
      complete: () => (this.isLoading = false),
      next: (response) => {
        this.userData = response.user;
      },
      error: (err) => alert(err),
    });
  }
}
