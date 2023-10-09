import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { inject } from "@angular/core";
import { LocalStorageService } from "@services/local-storage.service";
import { AuthService } from "@services/auth.service";
import { catchError, map, of } from "rxjs";

export const isAdminGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot,
  localStorageService = inject(LocalStorageService),
  authService = inject(AuthService),
  router = inject(Router)
) => {
  const currentUser = localStorageService.getCurrentUser();

  if (!currentUser) {
    alert("This resource is only for authorized administrators!");
    return router.createUrlTree(["main", "articles"]);
  }

  return authService.checkAdmin(currentUser.id).pipe(
    map((response) => {
      return response.isAdmin ? true : router.createUrlTree(["main", "articles"]);
    }),
    catchError(() => {
      alert("This resource is only for authorized administrators!");
      router.navigate(["main", "articles"]);
      return of(false);
    })
  );
};
