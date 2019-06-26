import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
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
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {

    this.getParamProjectAddIssue();
  }

  getParamProjectAddIssue() {
    this.route.params.subscribe(params => {
      this.paramAddIssueId = params['id'];
      this.checkProject();
      this.userService.getParamSpaceId(this.paramAddIssueId);
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
