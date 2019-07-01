import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IssueDetails } from 'src/app/shared/models/issuedetails.interface';
import { commentDetail } from 'src/app/shared/models/commentDetail.interface';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { IssueDetail } from 'src/app/shared/models/IssueDetail.interface';

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

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

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
      console.log('this');
      console.log(this.listComment);
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
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
        formComment.resetForm();
      }
    );
  }
}
