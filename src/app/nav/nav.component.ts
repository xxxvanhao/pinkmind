import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

declare var jquery: any;
declare var $: any;
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit, OnDestroy {

  status: boolean;
  subscription: Subscription;

  constructor(private userService: UserService, private router: Router) {

  }

  logout() {
    this.userService.logout();
    this.router.navigate(['/account/facebook-login']);
 }

  ngOnInit() {
    this.subscription = this.userService.authNavStatus$.subscribe(status => this.status = status);
  }
  ngOnDestroy() {
    // prevent memory leak when component is destroyed
    this.subscription.unsubscribe();
  }
}
