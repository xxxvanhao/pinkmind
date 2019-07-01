import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgStyle } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { Project } from 'src/app/shared/models/project.interface';
import { CountStatus } from 'src/app/shared/models/countStatus.interface';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  paramHomeId: string;
  isProjectKey: boolean;
  countStatus: CountStatus;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.getParamProjectHome();
    this.userService.getMilestone();
    this.userService.getCategory();
    this.userService.startConnection();
    this.userService.addBroadcastChartDataListener();
  }

  getParamProjectHome() {
      this.route.params.subscribe(params => {
      this.paramHomeId = params['id'];
      this.checkProject();
      this.getCountStatus();
      this.userService.getParamSpaceId(this.paramHomeId);
      this.userService.getReUpdate(this.paramHomeId);
      });
  }

  checkProject() {
    this.userService.getProject().then((res: any) => {
      for (const item of res) {
        if (item.id === this.paramHomeId) {
          this.isProjectKey = true;
        }
      }
      if (this.isProjectKey == undefined) {
        this.router.navigate(['dashboard']);
      }
    });
  }

  getCountStatus() {
    this.userService.getIssue(this.paramHomeId)
    .then((res: any) => {
      const sum = res.reduce((total, item) => {
        if (!total[item.statusName]) {
            total[item.statusName] = 0;
        }
        total[item.statusName]++;
        return total;
        }, {});
      this.countStatus =  {
        open: sum['Open'] == undefined ? 0 : sum['Open'],
        inprogress: sum['In Progress'] == undefined ? 0 : sum['In Progress'],
        resolved: sum['Resolved'] == undefined ? 0 : sum['Resolved'],
        closed: sum['Closed'] == undefined ? 0 : sum['Closed']
      };
    });
  }
}
