import { Component, OnInit } from "@angular/core";
import { LocalStorageService } from "src/app/services/local-storage.service";
import { Router } from "@angular/router";

@Component({
  selector: "app-main-page",
  templateUrl: "./main-page.component.html",
  styleUrls: ["./main-page.component.scss"],
})
export class MainComponent implements OnInit {
  login: string = "";
  isAuthorized: boolean = false;

  constructor(private storageService: LocalStorageService, private router: Router) {}

  ngOnInit(): void {
    const login = this.storageService.getLogin();

    if (login) {
      this.login = login;
      this.isAuthorized = true;
    }
  }

  onSignIn() {
    this.router.navigate(["auth"]);
  }

  onSignOut() {
    this.storageService.clean();
  }

  protected readonly navigator = navigator;
}
