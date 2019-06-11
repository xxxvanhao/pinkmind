import { Component, OnInit } from '@angular/core'; 
declare var getParameterByName: any;
@Component({
  selector: 'app-facebook-auth',
  templateUrl: './facebook-auth.component.html',
  styleUrls: ['./facebook-auth.component.css']
})
export class FacebookAuthComponent implements OnInit {

  constructor() { }
  ngOnInit() {
    // if we don't receive an access token then login failed and/or the user has not connected properly
    var accessToken = getParameterByName('access_token');
    var message = <any>{};
    if (accessToken) {
        message.status = true;
        message.accessToken = accessToken;
    } else {
        message.status = false;
        message.error = getParameterByName('error');
        message.errorDescription = getParameterByName('error_description');
    }
    console.log(message.accessToken);
    window.opener.postMessage(JSON.stringify(message), 'http://localhost:4200');

  }
}
