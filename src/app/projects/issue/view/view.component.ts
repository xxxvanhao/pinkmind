import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Router, ActivatedRoute } from '@angular/router';
import { IssueDetail } from 'src/app/shared/models/IssueDetail.interface';

@Component({
  selector: 'app-view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css']
})
export class ViewComponent implements OnInit {
  isProjectKey: boolean;
  paramIssueId: string;
  issueDetail: IssueDetail;
  
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getParamProjectIssue();
  }
  getParamProjectIssue() {
    this.route.params.subscribe(params => {
      this.paramIssueId = params['id'];
      this.checkProject();
      this.GetDetail();
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
  GetDetail(){
    this.userService.getIssueDetail().then((res: any) => {
      this.issueDetail = res;
    });
  }
}
