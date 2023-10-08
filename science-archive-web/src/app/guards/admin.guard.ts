import { ActivatedRouteSnapshot, CanActivateFn, Router, RouterStateSnapshot } from "@angular/router";
import { inject } from "@angular/core";
import { LocalStorageService } from "@services/local-storage.service";

export const isAdminGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot,
  localStorageService = inject(LocalStorageService),
  router = inject(Router)
) => {
  const currentUser = localStorageService.getCurrentUser();

  if (!currentUser) {
    alert("This resource is only for authorized administrators!");
    return router.createUrlTree(["main", "articles"]);
  }

  if (!currentUser.isAdmin) {
    alert("This resource is only for administrators!");
    return router.createUrlTree(["main", "articles"]);
  }

  return true;
};
