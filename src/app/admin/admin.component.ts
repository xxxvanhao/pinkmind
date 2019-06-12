import { Component, OnInit, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { UserService } from '../shared/services/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})
export class AdminComponent implements OnInit, OnDestroy {

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
