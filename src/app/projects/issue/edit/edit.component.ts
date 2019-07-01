import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { IssueDetail } from 'src/app/shared/models/IssueDetail.interface';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  issueDetail: IssueDetail;

  constructor(private userService: UserService, private router: Router, private toastr: ToastrService) { }

  ngOnInit() {
    this.userService.getMilestone();
    this.userService.getCategory();
    this.userService.getStatus();
    this.userService.getResolution();
    this.userService.getPriority();
    this.userService.getVersion();
    this.userService.getIssueType();
    this.GetDetail();
  }
  
  GetDetail() {
    if(this.userService.IssueDetail != null){
      this.issueDetail = this.userService.IssueDetail;
    }
    else{
      this.router.navigate(['dashboard']);
    }
  }
  onSubmit(formUpdateIssue: NgForm) {
    console.log(formUpdateIssue.value);
    this.userService.postComment(formUpdateIssue.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Update Issue successful');
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
      }
    );
  }
}
