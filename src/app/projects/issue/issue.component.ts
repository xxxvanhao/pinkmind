import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-issue',
  templateUrl: './issue.component.html',
  styleUrls: ['./issue.component.css']
})
export class IssueComponent implements OnInit {

  paramIssueId: string;
  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getParamProjectIssue();
  }
  getParamProjectIssue() {
    this.route.params.subscribe(params => {
      this.paramIssueId = params['id'];
      this.userService.getParamSpaceId(this.paramIssueId);
      });
  }
}
