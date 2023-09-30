import { Component, OnInit } from "@angular/core";
import { LocalStorageService } from "src/app/services/local-storage.service";
import { IdentifiedUser } from "@models/user/identified-user";

@Component({
  selector: "app-main-page",
  templateUrl: "./main-page.component.html",
  styleUrls: ["./main-page.component.scss"],
})
export class MainPageComponent implements OnInit {
  currentUser: IdentifiedUser | null = null;
  isAuthorized: boolean = false;
  isMobileMenuOpen: boolean = false;
  isShowAccountDrawer: boolean = false;

  constructor(private storageService: LocalStorageService) {}

  ngOnInit(): void {
    const user = this.storageService.getCurrentUser();
    const isAuthorized = this.storageService.isLoggedIn();

    if (user && isAuthorized) {
      this.currentUser = user;
      this.isAuthorized = true;
    } else {
      this.currentUser = null;
      this.isAuthorized = false;
    }
  }

  onSignOut() {
    this.storageService.clean();
    this.isShowAccountDrawer = false;
    this.ngOnInit();
  }

  onToggleMenu() {
    this.isMobileMenuOpen = !this.isMobileMenuOpen;
  }

  onCloseMenu() {
    this.isMobileMenuOpen = false;
  }

  onOpenDrawer() {
    this.isShowAccountDrawer = true;
  }

  onCloseDrawer() {
    this.isShowAccountDrawer = false;
  }

  protected readonly ontoggle = ontoggle;
}
