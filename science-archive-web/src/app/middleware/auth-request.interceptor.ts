import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { catchError, Observable, observeOn, throwError } from "rxjs";
import { LocalStorageService } from "@services/local-storage.service";

@Injectable()
export class AuthRequestInterceptor implements HttpInterceptor {
  constructor(private storageService: LocalStorageService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.storageService.getToken();

    if (token) {
      req = req.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }

    return next.handle(req).pipe(
      catchError((err: HttpErrorResponse) => {
        if (err.status === 401) {
          this.handleUnauthorized();
        }

        return throwError(() => err);
      })
    );
  }

  handleUnauthorized() {
    if (this.storageService.isLoggedIn()) {
      alert("Session expired. Please sign in again");
      this.storageService.clean();
    } else {
      alert("You should sign in");
    }
  }
}
