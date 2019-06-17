import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { UserDetails } from '../shared/models/userDetails.interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-wwwroot',
  templateUrl: './wwwroot.component.html',
  styleUrls: ['./wwwroot.component.css']
})
export class WwwrootComponent implements OnInit {
  userDetails: UserDetails;
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.userService.getUserDetails()
            .subscribe((userDetails: UserDetails) => {
              this.userDetails = userDetails;
              if (userDetails.spaceID == null) {

              }
            },
            error => {
              localStorage.clear();
              this.router.navigate(['account/facebook-login']);
              return error;
            });
  }

}
