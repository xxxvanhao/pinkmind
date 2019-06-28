import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

declare var jquery: any;
declare var $: any;
@Component({
  selector: 'app-addissue',
  templateUrl: './addissue.component.html',
  styleUrls: ['./addissue.component.css'],
})
export class AddissueComponent implements OnInit {

  paramAddIssueId: string;
  isProjectKey: boolean;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit() {
    this.getParamProjectAddIssue();
    this.userService.getMilestone();
    this.userService.getCategory();
    this.userService.getIssueType();
    this.userService.getPriority();
    this.userService.getResolution();
    this.userService.getVersion();
    this.userService.getStatus();
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
  onSubmit(formIssue: NgForm) {
    this.userService.postIssue(formIssue.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Register Issue');
        formIssue.resetForm();
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
        formIssue.resetForm();
      }
    );
  }
}
