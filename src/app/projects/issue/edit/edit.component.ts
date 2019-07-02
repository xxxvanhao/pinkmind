import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { IssueDetail } from 'src/app/shared/models/IssueDetail.interface';
import { Router, ActivatedRoute } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import * as moment from 'moment';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  issueDetail: IssueDetail;
  paramAddIssueId: string;
  isProjectKey: boolean;

  constructor(private userService: UserService, private router: Router,private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit() {
    this.getParamProjectAddIssue();
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
    this.userService.putIssue(formUpdateIssue.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Update Issue successful');
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
      }
    );
  }
  getParamProjectAddIssue() {
    this.route.params.subscribe(params => {
      this.paramAddIssueId = params['id'];
      this.checkProject();
      this.userService.getParamSpaceId(this.paramAddIssueId);
      this.userService.getProjectMember(this.paramAddIssueId);
    });
  }
  checkProject() {
    this.userService.getProject().then((res: any) => {
      for (const item of res) {
        if (item.id === this.paramAddIssueId) {
          this.isProjectKey = true;
        }
      }
      if (this.isProjectKey == undefined) {
        this.router.navigate(['dashboard']);
      }
    });
  }
}
