import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IssueDetails } from 'src/app/shared/models/issuedetails.interface';
import { commentDetail } from 'src/app/shared/models/commentDetail.interface';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IssueDetail } from 'src/app/shared/models/IssueDetail.interface';
import { postComment } from 'src/app/shared/models/postModel/postComment.interface';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { forEach } from '@angular/router/src/utils/collection';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  isProjectKey: boolean;
  paramIssueId: string;
  issueDetail: IssueDetail;
  listComment: commentDetail;
  baseUrl: string;
  paramAddIssueId: string;
  @ViewChild('form2', { read: NgForm })
  form2: any;

  constructor(private userService: UserService, private http: HttpClient, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit() {
    this.getParamProjectIssue();
    this.userService.getMilestone();
    this.userService.getCategory();
    this.userService.getStatus();
    this.userService.getResolution();
    this.userService.getPriority();
    this.userService.getVersion();
    this.userService.getIssueType();
  }
  getParamProjectIssue() {
    this.route.params.subscribe(params => {
      this.paramIssueId = params['id'];
      this.checkProject();
      this.GetDetail();
      this.userService.getParamSpaceId(this.paramIssueId);
    });
  }
  checkProject() {
    this.userService.getProject().then((res: any) => {
      for (const item of res) {
        if (item.id === this.paramIssueId) {
          this.isProjectKey = true;
        }
      }
      if (this.isProjectKey == undefined) {
        this.router.navigate(['dashboard']);
      }
    });
  }
  GetDetail() {
    if (this.userService.IssueDetail != null) {
      this.issueDetail = this.userService.IssueDetail;
      this.getAllComment(this.userService.IssueDetail.id);

    }
    else {
      this.router.navigate(['dashboard']);
    }
  }
  getAllComment(id: number) {
    this.userService.getComment(id).then((res: any) => {
      this.listComment = res.comments;
    });
  }
  redirect() {
    this.router.navigate(['projects/edit/' + this.issueDetail.projectID]);
  }
  active() {
    var elmAddComment = document.getElementById('add-comment');
    elmAddComment.classList.add('active-form');
    //active update issue form 
    var elmAddComment = document.getElementById('update-issue-atcm');
    elmAddComment.classList.add('is-active-form');
    const inputNotify = document.getElementById('notifyToUser');
    inputNotify.classList.add('is-active-form');
    var statusBegin = document.getElementsByClassName('status-item-update') as any;
    for (var item of statusBegin){
      if(item.getAttribute('value') == this.issueDetail.statusID){
        item.classList.add('active')
      }
    }
  }
  close() {
    var elmAddComment = document.getElementById('add-comment');
    elmAddComment.classList.remove('active-form');
    var elmAddComment = document.getElementById('update-issue-atcm');
    elmAddComment.classList.remove('is-active-form');
    const inputNotify = document.getElementById('notifyToUser');
    inputNotify.classList.remove('is-active-form');
  }
  onSubmit(formComment: NgForm) {
    var issueSubmit = document.getElementById('update-issue-atcm') as any;
    this.userService.postComment(formComment.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Add comment successful');
        issueSubmit.addEventListener('change', function () {
          var updateStatus = document.getElementById('update-statusID').getAttribute('value');
          var updateAssignee = (document.getElementById('update-assignee') as any).value;
          var updateDuedate = (document.getElementById('update-duedate') as any).value;
          var updateMileston = (document.getElementById('update-milestone') as any).value;
          var updateResolution = (document.getElementById('update-resolution') as any).value;
          this.issueDetail.statusID = Number(updateStatus);
          this.issueDetail.assigneeUser = updateAssignee;
          this.issueDetail.dueDate = updateDuedate;
          this.issueDetail.milestoneID = Number(updateMileston);
          this.issueDetail.resolutionID = Number(updateResolution);
          this.UpdateIssue(this.issueDetail);
        });
        this.getAllComment(this.userService.IssueDetail.id);
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
      }
    );
  }
  onSubmitChange(formComment: NgForm) {
    this.userService.putComment(formComment.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Update comment successful');
        formComment.resetForm();
        this.getAllComment(this.userService.IssueDetail.id);
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
      }
    );
  }
  UpdateIssue(issueDetail: IssueDetail) {
    this.userService.putIssue(issueDetail).subscribe(
      res => {
        this.toastr.success('Successful!', 'Update Issue successful');
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
      }
    );
  }
  UpdateComment(formComment: postComment) {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type': 'application/json'
    });
    return this.http.put(this.baseUrl + '/Issue', formComment, { headers })
      .pipe(map((response: any) => response))
  }
  activeFormEdit(event: Event, id: number) {
    var statusBegin = document.getElementsByClassName('status-item-update') as any;
    for (var item of statusBegin){
      if(item.getAttribute('value') == this.issueDetail.statusID){
        item.classList.add('active')
      }
    }
    const isItem = document.getElementsByClassName('edit-content') as any;
    for (const item of isItem) {
      if (id == item.getAttribute('id') && !item.classList.contains('is-active-form')) {
        item.classList.add('is-active-form');
      }
      else {
        item.classList.remove('is-active-form');
      }
    }
  }
  ChangeStatusValue(event, id: number) {
    var statusIDElm = document.getElementById('update-statusID');
    var changeStatus = document.getElementsByClassName('status-item-update') as any;
    statusIDElm.setAttribute("value", id.toString());
    for (const item of changeStatus) {
      if (id == item.getAttribute('value')) {
        item.classList.add('active');
      }
      else {
        item.classList.remove('active');
      }
    }
  }
  getParamProjectAddIssue() {
    this.route.params.subscribe(params => {
      this.paramAddIssueId = params['id'];
      this.checkProject();
      this.userService.getParamSpaceId(this.paramAddIssueId);
      this.userService.getProjectMember(this.paramAddIssueId);
    });
  }
}
