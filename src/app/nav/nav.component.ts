import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

declare var jquery: any;
declare var $: any;
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit, OnDestroy {

  status: boolean;
  subscription: Subscription;

  constructor(private userService: UserService, private router: Router) {

  }

  ngOnInit() {
    this.subscription = this.userService.authNavStatus$.subscribe(status => this.status = status);
    this.userService.getProject();
  }

  ngOnDestroy() {
    // prevent memory leak when component is destroyed
    this.subscription.unsubscribe();
  }

  logout() {
    this.userService.logout();
    this.router.navigate(['/account/facebook-login']);
 }

 searchProject() {
  const searchID = document.getElementById('project-search-id') as HTMLInputElement;
  const filter = searchID.value.toUpperCase();
  const filterProject = document.getElementsByClassName('filter-project')[0] as any;
  const projectName = filterProject.getElementsByClassName('project-name') as any;
  const projectContent = filterProject.getElementsByClassName('project-content') as any;
  // tslint:disable-next-line: prefer-for-of
  for (let i = 0; i < projectName.length; i++) {
      const txtValue = projectName[i].textContent || projectName[i].innerText;
      if (txtValue.toUpperCase().indexOf(filter) > -1) {
        projectContent[i].style.display = '';
      } else {
        projectContent[i].style.display = 'none';
      }
    }
  }
}