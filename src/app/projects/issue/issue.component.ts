import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrls: ['./issue.component.css']
})
export class IssueComponent implements OnInit {

  paramIssueId: string;
  isProjectKey: boolean;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getParamProjectIssue();
  }

  getParamProjectIssue() {
    this.route.params.subscribe(params => {
      this.paramIssueId = params['id'];
      this.checkProject();
      this.getIssue();
      this.userService.getParamSpaceId(this.paramIssueId);
      });
  }

  checkProject() {
    this.userService.getProject().then((res: any) => {
      for (const item of res) {
        if (item.id === this.paramIssueId) {
          this.isProjectKey = true;
        }
      }
      if (this.isProjectKey == undefined) {
        this.router.navigate(['dashboard']);
      }
    });
  }
  getIssue(){
    this.userService.getAllIssue("k")
  }
}
