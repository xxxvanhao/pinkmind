import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ReUpdate } from 'src/app/shared/models/reUpdate.interface';
import { getLocaleDateTimeFormat } from '@angular/common';

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
  reUpdate: ReUpdate;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService, private http: HttpClient) { }

  ngOnInit() {
    this.getParamProjectAddIssue();
    this.userService.getMilestone();
    this.userService.getCategory();
    this.userService.getIssueType();
    this.userService.getPriority();
    this.userService.getResolution();
    this.userService.getVersion();
    this.userService.getStatus();
    this.userService.startConnection();
    // this.userService.addTransferChartDataListener();
    this.userService.addBroadcastChartDataListener();
    // this.startHttpRequest();
  }

  private startHttpRequest = () => {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type': 'application/json'
    });
    this.http.get('http://localhost:5000/api/Reupdates/signalr/pkey', { headers })
      .subscribe(res => {
        console.log(res);
      });
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
        this.reUpdate = {
        avatarPath: this.userService.userDetails.pictureUrl,
        userName: `${this.userService.userDetails.firstName} ${this.userService.userDetails.lastName}`,
        actionName: 'added a new <span class="action">issue</span>',
        issueKey: formIssue.value.projectID + `-${res}`,
        subject: formIssue.value.subject,
        content: formIssue.value.description,
        updateTime: new Date(),
        spaceID: this.userService.userDetails.spaceID,
        projectKey: formIssue.value.projectID
        };
        this.userService.broadcastChartData(this.reUpdate);
        formIssue.setValue({
          projectID: `${this.paramAddIssueId}`,
          issueTypeID: '',
          subject: '',
          assigneeUser: '',
          description: '',
          milestoneID: '',
          categoryID: '',
          versionID: '',
          priorityID: '',
          dueDate: ''
        });
      },
      err => {
        this.toastr.error('Failed!', 'Please type again');
        formIssue.setValue({
          projectID: `${this.paramAddIssueId}`,
          issueTypeID: '',
          subject: '',
          assigneeUser: '',
          description: '',
          milestoneID: '',
          categoryID: '',
          versionID: '',
          priorityID: '',
          dueDate: ''
        });
      }
    );
  }
}
