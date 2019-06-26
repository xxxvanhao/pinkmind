import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { UserService } from '../shared/services/user.service';
import { NgForm } from '@angular/forms';

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
    this.checkAddUser();
    this.userService.getReUpdate('pkey');
    // setTimeout(this.checkProject, 1000);
    setTimeout(this.checkTimeLine, 1000);
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

  checkTimeLine() {
  const timeLine = document.getElementsByClassName('isNo-items timeline') as any;
  const issue = document.getElementsByClassName('issue') as any;
  if (timeLine.length > 0) {
      issue[0].style.marginLeft = '-35.63rem';
      issue[0].style.transition = '0.5s';
    } else {
      issue[0].style.marginLeft = '0px';
    }
  }
  onSubmit(formProject: NgForm) {
    this.userService.postProject(formProject.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Register Project');
        this.router.navigate([`/projects/home/${formProject.value.id}`]);
        formProject.resetForm();
        $('.modal-backdrop').remove();
      },
      err => {
        this.toastr.error('Failed!', 'Register Project');
        formProject.resetForm();
      }
    );
  }
}
