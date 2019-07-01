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

  categoryId: number = 0;
  milestoneId: number = 0;
  assigneeId: number = 0;
  statusId: number = 0;
  key : string = "";
  projectId :string;

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getParamProjectIssue();
    this.userService.getMilestone();
    this.userService.getCategory();
    this.userService.getStatus();
    this.SearchIssue();
    }

  getParamProjectIssue() {
    this.route.params.subscribe(params => {
      this.paramIssueId = params['id'];
      this.checkProject();
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
    
  SearchIssue(){
    this.projectId = 'KRS'
    this.categoryId = Number((document.getElementById("is-category-Category") as any).value);
    // if(!document.getElementsByClassName('is-active') as any != undefined){
    //   this.statusId = (document.getElementsByClassName('is-active') as any).getAttribute('id');
    // }
    console.log(this.statusId);
    this.milestoneId = Number((document.getElementById("is-milestone-Category") as any).value)
    this.key = (document.getElementById("keySearch") as any).value;
    
    console.log(this.key,this.categoryId, this.statusId,this.milestoneId, this.key)
    this.userService.getSearchIssue(this.projectId,this.categoryId,this.statusId,this.milestoneId,this.key);
    
  }
}
