import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserService } from '../shared/services/user.service';
import { NgForm } from '@angular/forms';
import { Observable } from 'rxjs';

declare var jquery: any;
declare var $: any;
@Component({
  selector: 'app-body',
  templateUrl: './body.component.html',
  styleUrls: ['./body.component.css']
})
export class BodyComponent implements OnInit {

  refId: any = document.getElementsByClassName('refId');
  openAdd: any = document.getElementsByClassName('add-user');
  constructor(private userService: UserService, private router: Router, private toastr: ToastrService) {

  }

  ngOnInit() {
    this.userService.getProject();
    this.checkAddUser();
    // setTimeout(this.checkProject, 1000);
    this.userService.getReUpdate();
  }

  checkProject() {
    const projectList = document.getElementsByClassName('project-list') as any;
    for (const project of projectList) {
      const projectContent = project.getElementsByClassName('project-content') as any;
      const isNoItems = project.getElementsByClassName('isNo-items') as any;

      if (projectContent.length > 0) {
        for (const item of isNoItems) {
          item.style.display = 'none';
        }
      } else {
        for (const item of isNoItems) {
          item.style.display = 'block';
        }
      }
    }
  }

  checkAddUser() {
    this.userService.checkSpaceControlDeltails()
        .subscribe((res: any) => {
          this.openAdd[0].style.pointerEvents = 'initial';
          this.refId[0].value = `http://localhost:4200/account/facebook-login?refid=${res.controlBy}`;
        },
        err => err);
  }
  onSubmit(formProject: NgForm) {
    this.userService.postProject(formProject.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Register Project');
        formProject.resetForm();
        $('.modal-backdrop').remove();
        this.router.navigate(['/projects/home'], { queryParams: { id: formProject.value.projectKey}});
      },
      err => {
        this.toastr.error('Failed!', 'Register Project');
        formProject.resetForm();
      }
    );
  }
}
