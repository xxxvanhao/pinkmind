import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgStyle } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { Project } from 'src/app/shared/models/project.interface';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  paramHomeId: string;
  isProjectKey: boolean;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) {
  }

  ngOnInit() {
    this.getParamProjectHome();
  }

  getParamProjectHome() {
      this.route.params.subscribe(params => {
      this.paramHomeId = params['id'];
      this.checkProject();
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
}
