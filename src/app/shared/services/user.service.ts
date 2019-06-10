import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ConfigService } from '../utils/config.service';
import {BaseService} from './base.service';
import { BehaviorSubject } from 'rxjs/';
import { map, catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  baseUrl: string = '';

  // Observable navItem source
  private _authNavStatusSource = new BehaviorSubject<boolean>(false);
  // Observable navItem stream
  authNavStatus$ = this._authNavStatusSource.asObservable();

  private loggedIn = false;

  constructor(private http: HttpClient, private configService: ConfigService) {
    super();
    this.loggedIn = !!localStorage.getItem('auth_token');
    // ?? not sure if this the best way to broadcast the status but seems to resolve issue on page refresh where auth status is lost in
    // header component resulting in authed user nav links disappearing despite the fact user is still logged in
    this._authNavStatusSource.next(this.loggedIn);
    this.baseUrl = configService.getApiURI();
  }

   login(userName, password) {
    const headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');

    return this.http.post(
      this.baseUrl + '/auth/login',
      JSON.stringify({ userName, password }), { headers }
      )
      .pipe(map((res: any) => res.json()))
      .pipe(map(res => {
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      }))
      .pipe(catchError(this.handleError));
  }

  logout() {
    localStorage.removeItem('auth_token');
    this.loggedIn = false;
    this._authNavStatusSource.next(false);
  }

  isLoggedIn() {
    return this.loggedIn;
  }

  facebookLogin(accessToken: string) {
    const headers = new HttpHeaders({
      'Content-Type' : 'application/json'
    });
    const body = JSON.stringify({ accessToken });
    return this.http.post(
      this.baseUrl + '/auth/facebook', body, { headers })
      .pipe(map((res: any) => {
        localStorage.setItem('auth_token', res.auth_token);
        this.loggedIn = true;
        this._authNavStatusSource.next(true);
        return true;
      }))
      .pipe(catchError(this.handleError));
  }
}
