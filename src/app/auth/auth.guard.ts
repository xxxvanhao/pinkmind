import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { UserService } from '../shared/services/user.service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private user: UserService, private router: Router) {}

  canActivate() {

    if (!this.user.isLoggedIn()) {
       this.router.navigate(['/account/facebook-login']);
       return false;
    }
    this.user.isSpaceId()
          .subscribe(result => {
          if (result) {
            return true;
          } else {
            this.router.navigate(['/space']);
          }
        },
        error => error);
    return true;
  }
}
