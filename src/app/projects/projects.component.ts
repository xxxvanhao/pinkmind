import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-projects',
  templateUrl: './projects.component.html',
  styleUrls: ['./projects.component.css']
})
export class ProjectsComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) {
 }

  ngOnInit() {
    this.userService.getIssueType();
    this.userService.getPriority();
    this.userService.getCategory();
    this.userService.getResolution();
    this.userService.getVersion();
    this.userService.getStatus();
  }
}
