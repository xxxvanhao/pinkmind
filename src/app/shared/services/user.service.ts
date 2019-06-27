import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { ConfigService } from '../utils/config.service';
import {BaseService} from './base.service';
import { BehaviorSubject, Observable, never, throwError, of } from 'rxjs/';
import { map, catchError } from 'rxjs/operators';
import { UserDetails } from '../models/userDetails.interface';
import { SpaceControlsDetails } from '../models/spaceControlsDetails.interface';
import { Space } from '../models/space.interface';
import { Project } from '../models/project.interface';
import { ReUpdate } from '../models/reUpdate.interface';
import * as moment from 'moment';
import { Issue } from '../models/issue.interface';
import { Issues } from '../models/Issues.interface';
@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  baseUrl: string;
  listProject: Project;
  userDetails: UserDetails;
  spaceId: string;
  listDateReUpdate: Date[];
  listReUpdate: ReUpdate;
  listIssue: Issue;
  Issues: Issues;

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

  getParamSpaceId(id: string) {
    this.spaceId = id;
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
    .pipe(map((response: any) => {
      this.userDetails = response;
      return response;
    } ))
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

  checkSpaceControlDeltails(): Observable<SpaceControlsDetails> {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + '/SpaceControls', { headers })
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

  // Project

  postProject(project: Project) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.post(this.baseUrl + '/Projects', project, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }

  getProject() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + '/Projects', {headers})
    .toPromise()
    .then((res: any) => this.listProject = res.projects);
    // .pipe(map((response: any) => response ))
    // .pipe(catchError(this.handleError));
  }

  // API GET

  getReUpdate(pKey: string) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/ReUpdates/${pKey}`, {headers})
    .toPromise()
    .then((res: any) => {
      this.listDateReUpdate = Array.from(new Set((res.reUpdateDTOs as any).map((item: any) =>
        moment(item.updateTime).format('MMM DD, YYYY'))));
      this.listReUpdate = res.reUpdateDTOs.reverse();
    });
  }

  getIssue(iKey: string) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Issue/${iKey}`, {headers})
    .toPromise()
    .then((res: any) => {
      this.listIssue = res;
    });
  }
  //GetAllIssue
  getAllIssue(projectKey: string/*,key: string ,AssigneeUser: number, CategoryID: number,MilestoneID: number,StatusID : number*/) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    // let SubURL = projectKey+ "?";
    // if(key != null){
    //     SubURL += "key="+ key + "&";
    // }
    // if(AssigneeUser != 0){
    //   SubURL += "AssigneeUser="+ AssigneeUser + "&";
    // }
    // if(CategoryID != 0){
    //   SubURL += "CategoryID="+ CategoryID + "&";
    // }
    // if(MilestoneID != 0){
    //   SubURL += "MilestoneID="+ MilestoneID + "&";
    // }
    // if(StatusID != 0){
    //   SubURL += "StatusID="+ StatusID + "&";
    // }
    return this.http.get(this.baseUrl + `/Issue/Search/MAm`, {headers})
    .toPromise()
    .then((res: any) => {
      this.Issues = res.Issues;
    });
    }
    getIssueDetail(ID: Number) {
      const authToken = localStorage.getItem('auth_token');
      const headers = new HttpHeaders({
        Authorization: `Bearer ${authToken}`,
        'Content-Type' : 'application/json'
      });
      return this.http.get(this.baseUrl + `/Issue/${ID}`, {headers})
      .toPromise()
      .then((res: any) => {
        this.listIssue = res.IssueDetail;
      });
    }
}
