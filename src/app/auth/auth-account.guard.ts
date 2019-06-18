import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { UserService } from '../shared/services/user.service';

@Injectable()
export class AuthAccountGuard implements CanActivate {
  constructor(private user: UserService, private router: Router) {}

  canActivate() {

    if (this.user.isLoggedIn()) {
      this.user.isSpaceId()
          .subscribe(result => {
          if (result) {
            this.router.navigate(['/dashboard']);
          } else {
            this.router.navigate(['/space']);
          }
        },
        error => error);
     }

    return true;

  }
}
