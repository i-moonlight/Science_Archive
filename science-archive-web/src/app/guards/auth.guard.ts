import { inject } from "@angular/core";
import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { LocalStorageService } from "@services/local-storage.service";

export const isAuthorizedGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot,
  localStorageService = inject(LocalStorageService),
  router = inject(Router)
) => {
  if (!localStorageService.isLoggedIn()) {
    alert("This resource is only for authorized users!");
    return router.createUrlTree(["/auth"]);
  }

  return true;
};
