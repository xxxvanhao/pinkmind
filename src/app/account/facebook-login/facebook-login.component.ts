import { Component } from '@angular/core';
import { UserService } from '../../shared/services/user.service';
import { Router } from '@angular/router';
import { finalize } from 'rxjs/operators';
import { UserDetails } from 'src/app/shared/models/userDetails.interface';

@Component({
  selector: 'app-facebook-login',
  templateUrl: './facebook-login.component.html',
  styleUrls: ['./facebook-login.component.css']
})
export class FacebookLoginComponent {

  failed: boolean;
  error: string;
  errorDescription: string;
  isRequesting: boolean;

  getParaByName(name, url) {
    if (!url) { url = window.location.href; }
    name = name.replace(/[\[\]]/g, '\\$&');
    const regex = new RegExp('[?&#]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url);
    if (!results) { return null; }
    if (!results[2]) { return ''; }
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
  }

  launchFbLogin() {
    window.open('https://www.facebook.com/v3.2/dialog/oauth?&response_type=token&display=popup&client_id=579347222556886&display=popup&redirect_uri=http://localhost:4200/&scope=email', null, 'width=600,height=400');
  }

  constructor(private userService: UserService, private router: Router) {
    const refId = this.getParaByName('refid', null);
    if (refId != null) {
      window.open(`https://www.facebook.com/v3.2/dialog/oauth?&response_type=token&display=popup&client_id=579347222556886&display=popup&redirect_uri=http://localhost:4200/?refid=${refId}&scope=email`, null, 'width=600,height=400');
    }
    if (window.addEventListener) {
      window.addEventListener('message', this.handleMessage.bind(this), false);
    } else {

       (<any>window).attachEvent('onmessage',  this.handleMessage.bind(this));
    }
  }

  handleMessage(event: Event) {
    const message = event as MessageEvent;
    // Only trust messages from the below origin.
    if (message.origin !== 'http://localhost:4200') {
      return;
  }
    window.close();
    const result = JSON.parse(message.data);
    const status = result.status;
    const accessTK = result.accessToken;
    const refId = result.refId;
    console.log(refId);
    if (!status) {
      this.failed = true;
      this.error = result.error;
      this.errorDescription = result.errorDescription;
    } else {
      this.failed = false;
      this.isRequesting = true;
      this.userService.facebookLogin(accessTK)
        .pipe(finalize(() => this.isRequesting = false))
        .subscribe(result => {
          if (result) {
            this.userService.getUserDetails()
            .subscribe((userDetails: UserDetails) => {
              if (userDetails.spaceID == null) {
                this.router.navigate(['/account/space']);
              } else {
                this.router.navigate(['/dashboard']);
              }
            },
            error => error);
          }
        },
        error => {
          this.failed = true;
          this.error = error;
        });
    }
  }
}
