import { Injectable } from "@angular/core";
import { IdentifiedUser } from "@models/user/identified-user";

@Injectable({
  providedIn: "root",
})
export class LocalStorageService {
  constructor() {}

  clean(): void {
    localStorage.clear();
  }

  public saveToken(token: string) {
    localStorage.removeItem(LocalStorageKeys.ApiToken);
    localStorage.setItem(LocalStorageKeys.ApiToken, token);
  }

  public getToken(): string | null {
    return localStorage.getItem("api_token");
  }

  public isLoggedIn(): boolean {
    const token = this.getToken();
    return !!token;
  }

  public saveCurrentUser(user: IdentifiedUser): void {
    localStorage.setItem(LocalStorageKeys.CurrentUser, JSON.stringify(user));
  }

  public getCurrentUser(): IdentifiedUser | null {
    const userJson = localStorage.getItem(LocalStorageKeys.CurrentUser);

    if (userJson) {
      return JSON.parse(userJson) as IdentifiedUser;
    }

    return null;
  }
}

enum LocalStorageKeys {
  ApiToken = "api_token",
  CurrentUser = "current_user",
}
