import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-projectsetting',
  templateUrl: './projectsetting.component.html',
  styleUrls: ['./projectsetting.component.css']
})
export class ProjectsettingComponent implements OnInit {

  paramSettingId: string;
  isProjectKey: boolean;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getParamProjectSetting();
  }
  getParamProjectSetting() {
    this.route.params.subscribe(params => {
      this.paramSettingId = params['id'];
      this.checkProject();
      this.userService.getParamSpaceId(this.paramSettingId);
      });
  }

  checkProject() {
    this.userService.getProject().then((res: any) => {
      for (const item of res) {
        if (item.id === this.paramSettingId) {
          this.isProjectKey = true;
        }
      }
      if (this.isProjectKey == undefined) {
        this.router.navigate(['dashboard']);
      }
    });
  }
}
