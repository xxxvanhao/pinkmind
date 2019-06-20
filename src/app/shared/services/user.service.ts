import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ConfigService } from '../utils/config.service';
import {BaseService} from './base.service';
import { BehaviorSubject, Observable } from 'rxjs/';
import { map, catchError } from 'rxjs/operators';
import { UserDetails } from '../models/userDetails.interface';
import { CodegenComponentFactoryResolver } from '@angular/core/src/linker/component_factory_resolver';
import { SpaceControlsDetails } from '../models/spaceControlsDetails.interface';
import { Space } from '../models/space.interface';
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


  isSpaceId() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + '/users', {headers})
    .pipe(map((response: any) => {
      if (response.spaceID != null) {
        return true;
      } else {
        return false;
      }
    }))
    .pipe(catchError(this.handleError));
  }

  getUserDetails(): Observable<UserDetails> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization : `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + '/Users', { headers })
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }

  putUser(userDetails: UserDetails) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.put(this.baseUrl + '/Users', userDetails, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }

  // team

  postSpace(space: Space) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.post(this.baseUrl + '/Spaces', space, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }

  // space control

  getSpaceControlDeltails(refId: string): Observable<SpaceControlsDetails> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    const body = JSON.parse(JSON.stringify({ refId }));
    return this.http.get(this.baseUrl + `/SpaceControls/${body.refId}`, { headers })
      .pipe(map((response: any) => response ))
      .pipe(catchError(this.handleError));
  }

  postSpaceControl(spaceControlsDetails: SpaceControlsDetails) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.post(this.baseUrl + '/Spaces', spaceControlsDetails, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }
}
