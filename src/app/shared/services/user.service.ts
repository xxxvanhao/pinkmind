import { Injectable, enableProdMode } from '@angular/core';
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
import * as signalR from "@aspnet/signalr";
import { Issue } from '../models/issue.interface';
import { IGetType } from '../models/igettype.interface';
import { IIssueType } from '../models/issuetype.interface';
import { ProjectMember } from '../models/projectmember.interface';
import { IssueDetails } from '../models/issuedetails.interface';


import { IssueDetail } from '../models/IssueDetail.interface';
import { FileUpload } from '../models/fileupload.interface';

import { commentDetail } from '../models/commentDetail.interface';
import { postComment } from '../models/postModel/postComment.interface';
import { putIssue } from '../models/postModel/putIssue.interface';

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  baseUrl: string;
  listProject: Project;
  userDetails: UserDetails;
  spaceId: string;
  projectMember: ProjectMember;
  listDateReUpdate: Date[];
  listReUpdate: ReUpdate[];
  listIssue: Issue;
  issueDetails: IssueDetails;
  mileStone: IGetType;
  issueType: IIssueType;
  listVersion: IGetType;
  listResolution: IGetType;
  listPriority: IGetType;
  listCategory: IGetType;
  listStatus: IGetType;
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e

  listFileDetails: FileUpload;
  listSearchIssue: IssueDetails;
  IssueDetail: IssueDetail;
<<<<<<< HEAD
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e

  listFileDetails: FileUpload;
  listSearchIssue: IssueDetails;
  IssueDetail: IssueDetail;
  
    // signalR
=======

  // signalR
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
  public bradcastedData: ReUpdate[];
  private hubConnection: signalR.HubConnection;
  public startConnection = () => {
    this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl('http://localhost:5000/reupdate')
                            .build();
    this.hubConnection
      .start()
      .then(() => console.log('Connection started'))
      .catch(err => console.log('Error while starting connection: ' + err));
  }

  public addTransferChartDataListener = () => {
    this.hubConnection.on('transferreupdata', (data) => {
      this.bradcastedData = data;
    });
  }

  public broadcastChartData = (data: any) => {
    this.hubConnection.invoke('broadcastchartdata', data)
    .catch(err => console.error(err));
  }

  public addBroadcastChartDataListener = () => {
    const self = this as any;
    this.hubConnection.on('broadcastchartdata', (data) => {
      self.listReUpdate.unshift(data);
    });
  }
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

  getProjectMember(pmParam: string) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/teamdetails/getall/${pmParam}`, {headers})
    .toPromise()
    .then((res: any) => {
      this.projectMember = res.teamDetails;
    });
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
      this.listReUpdate = res.reUpdateDTOs;
    });
  }

  getIssue(iKey: string) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Issue/GetByUser/${iKey}`, {headers})
    .toPromise()
    .then((res: any) => this.issueDetails = res.issues);
  }
  getMilestone() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Mileston/getall`, {headers})
    .toPromise()
    .then((res: any) => {
      this.mileStone = res.milestons;
    });
  }
  getCategory() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Category/getall`, {headers})
    .toPromise()
    .then((res: any) => {
      this.listCategory = res.categories;
    });
  }

  getIssueType() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/issuetype/getall`, {headers})
    .toPromise()
    .then((res: any) => {
      this.issueType = res.issueTypes;
    });
  }

  getVersion() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Version/getall`, {headers})
    .toPromise()
    .then((res: any) => {
      this.listVersion = res.versions;
    });
  }

  getStatus() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Status/getall`, {headers})
    .toPromise()
    .then((res: any) => {
      this.listStatus = res.statuses;
    });
  }

  getPriority() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Priority/getall`, {headers})
    .toPromise()
    .then((res: any) => {
      this.listPriority = res.priorities;
    });
  }

  getResolution() {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Resolution/getall`, {headers})
    .toPromise()
    .then((res: any) => {
      this.listResolution = res.resolutions;
    });
  }

  getFile(path: string) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    const urlpath = encodeURIComponent(path);
    return this.http.get(this.baseUrl + `/FileUpload/folder/${urlpath}`, {headers})
    .toPromise()
    .then((res: any) => {
      this.listFileDetails = res.fileDTOs;
      return res;
    });
  }

  // Post Issue

  postIssue(issue: Issue) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.post(this.baseUrl + '/issue', issue, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }

  getIssueDetail(id: number) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.post(this.baseUrl + '/issue/'+ id, {headers}).toPromise();
  }

  getSearchIssue(proID:string,catID: number,staID:number,mileID:number,key:string) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/issue/search/`+ proID + "?key="+key+ "&CategoryID="+catID +"&MilestoneID="+mileID+"&StatusID="+staID, {headers})
    .toPromise()
    .then((res: any) => {
      this.listSearchIssue = res.issues;
    });
  }
  // Get comment : Hoang
  getComment(issueID: number){
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + `/Comment/getall/` + issueID, {headers}).toPromise();
  }
<<<<<<< HEAD
<<<<<<< HEAD
  
  // Post folder-file
  // return this.http.get(this.baseUrl + `/Comment/getall/`+ issueID, {headers}).toPromise();

  //Post comment : Hoang
  postComment(postComment: postComment) {
=======
=======
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e

  // Post folder-file
  // return this.http.get(this.baseUrl + `/Comment/getall/`+ issueID, {headers}).toPromise();

  postFolder(path: FileUpload) {
<<<<<<< HEAD
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
=======
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
<<<<<<< HEAD
<<<<<<< HEAD
    return this.http.post(this.baseUrl + '/Comment/Create', postComment, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }
  postFolder(path: FileUpload) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
    });
=======
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
=======
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
    return this.http.post(this.baseUrl + '/FileUpload', path, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
    }
<<<<<<< HEAD
<<<<<<< HEAD
      'Content-Type' : 'application/json'
      //Post comment : Hoang
  putComment(putComment: postComment) {
=======
=======
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
  //Post comment : Hoang
  postComment(postComment: postComment) {
    console.log(postComment);
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.put(this.baseUrl + '/Comment/Update', putComment, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }

  //put: Update issue
  putIssue(putIssueForm: putIssue) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.put(this.baseUrl + '/Issue/Update', putIssueForm, {headers})
    .pipe(map((response: any) => response ))
    .pipe(catchError(this.handleError));
  }
<<<<<<< HEAD
<<<<<<< HEAD
  //get Search issue for search global
  SearchIssue(key:string){
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + '/Issue/SearchGlobal/'+ key, {headers})
    .toPromise();
  }
  SearchMember(key: string){
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.get(this.baseUrl + '/User/SearchGlobal/'+ key, {headers})
    .toPromise();
  }
=======
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
=======
>>>>>>> 49f7096b7a04026ef8397289a55492ec96a76c4e
}
