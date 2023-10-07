import { Component, OnInit } from "@angular/core";
import { LocalStorageService } from "src/app/services/local-storage.service";
import { IdentifiedUser } from "@models/user/identified-user";
import { ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-main-page",
  templateUrl: "./main-page.component.html",
  styleUrls: ["./main-page.component.scss"],
})
export class MainPageComponent implements OnInit {
  currentUser: IdentifiedUser | null = null;

  isAuthorized = false;
  isMobileMenuOpen = false;
  isShowAccountDrawer = false;
  activePanel!: string;

  constructor(private readonly storageService: LocalStorageService, private readonly route: ActivatedRoute) {}

  ngOnInit(): void {
    const user = this.storageService.getCurrentUser();
    const isAuthorized = this.storageService.isLoggedIn();

    if (user && isAuthorized) {
      this.currentUser = user;
      this.isAuthorized = true;
    } else {
      this.isAuthorized = false;
      this.currentUser = null;
    }

    const routeSnapshot = this.route.snapshot;
    const routeSegments = routeSnapshot.url;

    if (routeSegments.length < 2) {
      this.activePanel = "";
    } else {
      this.activePanel = routeSegments[2].path;
    }

    console.log(this.activePanel);
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
