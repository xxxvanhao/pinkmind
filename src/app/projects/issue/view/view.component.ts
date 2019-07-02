import { Component, OnInit } from '@angular/core';
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

  constructor(private userService: UserService,private http: HttpClient, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit() {
    this.getParamProjectIssue();
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
  }
  close() {
    var elmAddComment = document.getElementById('add-comment');
    elmAddComment.classList.remove('active-form');
  }
  onSubmit(formComment: NgForm) {
    console.log(formComment.value);
    this.userService.postComment(formComment.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Add comment successful');
        formComment.resetForm();
        this.getAllComment(this.userService.IssueDetail.id);
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
        formComment.resetForm();
      }
    );
  }
  onSubmitChange(formComment: NgForm) {
    console.log(formComment.value);
    this.userService.putComment(formComment.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Add comment successful');
        formComment.resetForm();
        this.getAllComment(this.userService.IssueDetail.id);
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
        formComment.resetForm();
      }
    );
  }
  UpdateComment(formComment: postComment){
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    return this.http.put(this.baseUrl + '/Issue', formComment, {headers})
    .pipe(map((response: any) => response ))
  }
  activeFormEdit(event: Event, id: number) {
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
}
