import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-projectsetting',
  templateUrl: './projectsetting.component.html',
  styleUrls: ['./projectsetting.component.css']
})
export class ProjectsettingComponent implements OnInit {

  paramSettingId: string;
  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getParamProjectSetting();
  }
  getParamProjectSetting() {
    this.route.params.subscribe(params => {
      this.paramSettingId = params['id'];
      this.userService.getParamSpaceId(this.paramSettingId);
      });
  }
}
