import { Component, OnInit } from "@angular/core";
import { SystemService } from "@services/system.service";

@Component({
  selector: "app-auth-page",
  templateUrl: "./auth-page.component.html",
  styleUrls: ["./auth-page.component.scss"],
})
export class AuthPageComponent implements OnInit {
  isSignIn: boolean;
  isSignUp: boolean;
  isServerWorking: boolean;

  constructor(private systemService: SystemService) {
    this.isServerWorking = true;
    this.isSignIn = false;
    this.isSignUp = true;
  }

  ngOnInit(): void {
    this.systemService.checkSystemStatus().subscribe({
      next: (response) => (this.isServerWorking = response.isWorking),
      error: () => {
        this.isServerWorking = false;
      },
    });
  }

  public changeAuthType(value: string): void {
    this.isSignIn = value === "sign-in";
    this.isSignUp = value === "sign-up";
  }
}
