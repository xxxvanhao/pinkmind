import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserService } from '../shared/services/user.service';
import { NgForm } from '@angular/forms';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IssueDetails } from '../shared/models/issuedetails.interface';
import * as moment from 'moment';

declare var jquery: any;
declare var $: any;
@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {

  refId: any = document.getElementsByClassName('refId');
  openAdd: any = document.getElementsByClassName('add-user');
  issueDetails: IssueDetails;
  iFilter: string;
  constructor(private userService: UserService, private router: Router, private toastr: ToastrService, private http: HttpClient) {

  }

  ngOnInit() {
    this.checkAddUser();
    this.userService.getReUpdate('pkey');
    // setTimeout(this.checkProject, 1000);
    setTimeout(this.checkTimeLine, 1000);
    this.ifSubmit('Assigned');
    this.userService.startConnection();
    this.userService.addBroadcastChartDataListener();
    // this.userService.addTransferChartDataListener();
    // this.startHttpRequest();
  }

  private startHttpRequest = () => {
    const authToken = localStorage.getItem('auth_token');
    const headers = new HttpHeaders({
      Authorization : `Bearer ${authToken}`,
      'Content-Type' : 'application/json'
    });
    this.http.get('http://localhost:5000/api/Reupdates/signalr/pkey', { headers })
      .subscribe(res => {
        console.log(res);
      });
  }

  checkProject() {
    const projectList = document.getElementsByClassName('project-list') as any;
    for (const project of projectList) {
      const projectContent = project.getElementsByClassName('project-content') as any;
      const isNoItems = project.getElementsByClassName('isNo-items') as any;

      if (projectContent.length > 0) {
        for (const item of isNoItems) {
          item.style.display = 'none';
        }
      } else {
        for (const item of isNoItems) {
          item.style.display = 'block';
        }
      }
    }
  }

  checkAddUser() {
    this.userService.checkSpaceControlDeltails()
        .subscribe((res: any) => {
          this.openAdd[0].style.pointerEvents = 'initial';
          this.refId[0].value = `http://localhost:4200/account/facebook-login?refid=${res.controlBy}`;
        },
        err => err);
  }

  checkTimeLine() {
  const timeLine = document.getElementsByClassName('isNo-items timeline') as any;
  const issue = document.getElementsByClassName('issue') as any;
  if (timeLine.length > 0) {
      issue[0].style.marginLeft = '-105.6%';
      issue[0].style.transition = '0.5s';
    } else {
      issue[0].style.marginLeft = '0px';
    }
  }
  onSubmit(formProject: NgForm) {
    this.userService.postProject(formProject.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Register Project');
        this.router.navigate([`/projects/home/${formProject.value.id}`]);
        formProject.resetForm();
        $('.modal-backdrop').remove();
      },
      err => {
        this.toastr.error('Failed!', 'Register Project');
        formProject.resetForm();
      }
    );
  }

  ifSubmit(iParam: string) {
    const ifClick = document.getElementById('if-click') as any;
    const isItem = ifClick.getElementsByClassName('is-item') as any;
    for (const item of isItem) {
      item.addEventListener('click', () => {
      const current = document.getElementsByClassName('if-active');
      current[0].className = current[0].className.replace(' if-active', '');
      item.className += ' if-active';
      });
    }
    this.iFilter = iParam;
    const self = this;
    this.userService.getIssue(iParam).then((res: any) => {
      self.issueDetails = res;
    });

    const ifClick_click = document.getElementById('idd-click') as any;
    const isItem_click = ifClick_click.getElementsByClassName('is-item')[0] as any;
    isItem_click.click();
  }

  iddSubmit(iParam: string) {
    const ifClick = document.getElementById('idd-click') as any;
    const isItem = ifClick.getElementsByClassName('is-item') as any;
    for (const item of isItem) {
      item.addEventListener('click', () => {
      const current = document.getElementsByClassName('idd-active');
      current[0].className = current[0].className.replace(' idd-active', '');
      item.className += ' idd-active';
      });
    }
    switch (iParam) {

      case '4day':
        this.userService.getIssue(iParam).then((res: any) => {
        this.issueDetails = res.filter((item) => {
            const now = new Date();
            const datenow = `${now.getMonth()}/${now.getDate()}/${now.getFullYear()}`;
            const createday = new Date(item.createAt);
            const createAtTime = `${createday.getMonth()}/${createday.getDate()}/${createday.getFullYear()}`;
            const secondstime = new Date(datenow).getTime() - new Date(createAtTime).getTime();
            const fourday = Math.floor(secondstime / (3600 * 24));
            return fourday == 4000;
          });
        });
        break;

      case 'duetoday':
        this.userService.getIssue(iParam).then((res: any) => {
        this.issueDetails = res.filter((item) => {
            const now = new Date();
            const datenow = `${now.getMonth()}/${now.getDate()}/${now.getFullYear()}`;
            const duetime = new Date(item.dueDate);
            const duedate = `${duetime.getMonth()}/${duetime.getDate()}/${duetime.getFullYear()}`;
            return duedate == datenow;
          });
        });
        break;

      case 'overdue':
        this.userService.getIssue(iParam).then((res: any) => {
        this.issueDetails = res.filter((item) => {
            const now = new Date();
            const datenow = `${now.getMonth()}/${now.getDate()}/${now.getFullYear()}`;
            const duetime = new Date(item.dueDate);
            const duedate = `${duetime.getMonth()}/${duetime.getDate()}/${duetime.getFullYear()}`;
            return duedate < datenow;
          });
        });
        break;

      default:
        this.userService.getIssue(iParam).then((res: any) => {
        this.issueDetails = res;
        });
        break;
    }
  }
}
