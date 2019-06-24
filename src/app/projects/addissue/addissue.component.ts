import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getParamProjectAddIssue();
  }
  getParamProjectAddIssue() {
    this.route.params.subscribe(params => {
      this.paramAddIssueId = params['id'];
      this.userService.getParamSpaceId(this.paramAddIssueId);
      });
  }
}
