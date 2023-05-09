import { Component, OnInit } from "@angular/core";
import { LocalStorageService } from "src/app/services/local-storage.service";

@Component({
  selector: "app-main-page",
  templateUrl: "./main-page.component.html",
  styleUrls: ["./main-page.component.scss"],
})
export class MainPageComponent implements OnInit {
  login: string = "";
  isAuthorized: boolean = false;

  constructor(private storageService: LocalStorageService) {}

  ngOnInit(): void {
    const login = this.storageService.getLogin();

    if (login) {
      this.login = login;
      this.isAuthorized = true;
    }
  }

  onSignIn() {
    window.location.href = "auth";
  }

  onSignOut() {
    this.storageService.clean();
  }
}
