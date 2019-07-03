import { Component, OnInit, AfterViewInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { ReUpdate } from 'src/app/shared/models/reUpdate.interface';
import { getLocaleDateTimeFormat } from '@angular/common';
import { FileIssue } from 'src/app/shared/models/fileissue.interface';
import { resolve } from 'url';
import { UserDetails } from 'src/app/shared/models/userDetails.interface';

declare var jquery: any;
declare var $: any;
@Component({
  selector: 'app-addissue',
  templateUrl: './addissue.component.html',
  styleUrls: ['./addissue.component.css'],
})
export class AddissueComponent implements OnInit, AfterViewInit {
  paramAddIssueId: string;
  isProjectKey: boolean;
  reUpdate: ReUpdate;
  listFile: FileIssue[];
  listNoti: UserDetails[];
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

  ngAfterViewInit(): void {
    $(".js-example-basic-multiple").select2();
  }
  private startHttpRequest = () => {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization: `Bearer ${authToken}`,
      'Content-Type': 'application/json'
    });
    this.http.get('http://localhost:5000/api/Reupdates/signalr/pkey', { headers })
      .subscribe(res => res);
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
   async onSubmit(formIssue: NgForm) {
    this.listFile = [];
    const fileInput = document.getElementById('eFileInput') as any;
    if (fileInput.files.length > 0) {
      await this.UploadFileIssue();
    }

    const listNoti = $('.js-example-basic-multiple').select2('data');
    const arrNoti = [];
    for (const item of listNoti) {
      arrNoti.push(parseInt(item.id));
    }

    const iFormValue =  {
          projectID: formIssue.value.projectID,
          issueTypeID: formIssue.value.issueTypeID,
          subject: formIssue.value.subject,
          assigneeUser: formIssue.value.assigneeUser,
          description: formIssue.value.description,
          milestoneID: formIssue.value.milestoneID,
          categoryID: formIssue.value.categoryID,
          versionID: formIssue.value.versionID,
          priorityID: formIssue.value.priorityID,
          dueDate: formIssue.value.dueDate,
          fileIssue: this.listFile,
          listNotification: arrNoti
    };
    
    this.userService.postIssue(iFormValue).subscribe(
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
        fileInput.value = '';
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
        fileInput.value = '';
      }
    );
  }

    UploadFileIssue() {
      return new Promise( (resolve) => {
        const pathFile = `${this.userService.userDetails.spaceID}/${this.paramAddIssueId}`;
        const pathEncode = encodeURIComponent(pathFile);
        const formdata = new FormData(); // FormData object
        const fileInput = document.getElementById('eFileInput') as any;
        // Iterating through each files selected in fileInput
        for (let i = 0; i < fileInput.files.length; i++) {
            // Appending each file to FormData object
            formdata.append(fileInput.files[i].name, fileInput.files[i]);
        }
        // Creating an XMLHttpRequest and sending
        const xhr = new XMLHttpRequest();
        const authToken = localStorage.getItem('auth_token');
        xhr.open('POST', `http://localhost:5000/api/FileUpload/path/${pathEncode}`);
        xhr.setRequestHeader('Authorization', `Bearer ${authToken}`);
        xhr.send(formdata);
        xhr.onreadystatechange = () => {
            if (xhr.readyState == 4 && xhr.status == 200) {
              const jsonParseFile = JSON.parse(xhr.responseText);
              this.listFile = jsonParseFile.pathListFile;
              resolve(true);
            }
        };
      });
  }
}
