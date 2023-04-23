import {Injectable} from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class LocalStorageService {
  constructor() {}

  clean(): void {
    localStorage.clear();
  }

  public saveToken(token: string) {
    localStorage.removeItem("api_token");
    localStorage.setItem("api_token", token);
  }

  public getToken(): string | null {
    return localStorage.getItem("api_token");
  }

  public isLoggedIn(): boolean {
    const token = this.getToken();

    return !!token;
  }

  public getLogin(): string | null {
    return localStorage.getItem("login");
  }

  public saveLogin(login: string): void {
    localStorage.removeItem("login");
    localStorage.setItem("login", login);
  }
}
