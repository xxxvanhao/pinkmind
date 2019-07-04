import { Component, OnInit, OnDestroy } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
<<<<<<< HEAD
import { searchUserModel } from '../shared/models/postModel/searchUserModel.interface';
import { searchIssueModel } from '../shared/models/SearchIssueModel.interface';
import { IssueDetail } from '../shared/models/IssueDetail.interface';
=======
import { Notify } from '../shared/models/notify.interface';
import { searchUserModel } from '../shared/models/postModel/searchUserModel.interface';
import { searchIssueModel } from '../shared/models/SearchIssueModel.interface';

>>>>>>> c8164f3717d232480e774ceea613430b3124df52

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
  listSearchUser: searchUserModel = null;
  listSearchIssue: searchIssueModel = null;

  listNotify: Notify;
  listSearchUser: searchUserModel = null;
  listSearchIssue: searchIssueModel = null;

  constructor(private userService: UserService, private router: Router) {

  }

  ngOnInit() {
    this.subscription = this.userService.authNavStatus$.subscribe(status => this.status = status);
    this.userService.getProject();
    this.getListNotify();
  }

  ngOnDestroy() {
    // prevent memory leak when component is destroyed
    this.subscription.unsubscribe();
  }

  logout() {
    this.userService.logout();
    this.router.navigate(['/account/facebook-login']);
<<<<<<< HEAD
  }
=======
 }

  getListNotify() {
    this.userService.getNotify().then((res: any) => {
      this.listNotify = res.notifies;
      console.log(res);
      console.log(this.listNotify)
    });
 }

//  searchProject() {
//   const searchID = document.getElementById('project-search-id') as HTMLInputElement;
//   const filter = searchID.value.toUpperCase();
//   const filterProject = document.getElementsByClassName('filter-project')[0] as any;
//   const projectName = filterProject.getElementsByClassName('project-name') as any;
//   const projectContent = filterProject.getElementsByClassName('project-content') as any;
//   // tslint:disable-next-line: prefer-for-of
//   for (let i = 0; i < projectName.length; i++) {

//   }
>>>>>>> c8164f3717d232480e774ceea613430b3124df52

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
  searchAny(key: string) {
    var openPopup = document.getElementById('popupSearch');
    if (key != "") {
      openPopup.classList.add('showPopup');
      this.userService.SearchMember(key).then((res: any) => {
        this.listSearchUser = res.searchUsers;
        var countIssue = res.searchUsers.length;
<<<<<<< HEAD
        (document.getElementById('count-member') as any).innerHTML = countIssue;
=======
        (document.getElementById('count-issue') as any).innerHTML = countIssue;
>>>>>>> c8164f3717d232480e774ceea613430b3124df52
      });
      this.userService.SearchIssue(key).then((res: any) => {
        this.listSearchIssue = res.issueSearches;
        var countmember = res.issueSearches.length;
<<<<<<< HEAD
        (document.getElementById('count-issue') as any).innerHTML = countmember;
      });
    }

    else {
      openPopup.classList.remove('showPopup');
    }
  }
  close() {
    var closeElm = document.getElementById('close-search-form');
    document.getElementById('popupSearch').classList.remove('showPopup');
  }

=======
        (document.getElementById('count-member') as any).innerHTML = countmember;
      });
    }
    else{
      openPopup.classList.remove('showPopup');
    }
  }
>>>>>>> c8164f3717d232480e774ceea613430b3124df52
  searchSpace() {
    const spaceName = document.getElementById('searchSpace') as HTMLInputElement;
    let showPopup = document.getElementsByClassName('showPopup')[0] as any;
    if (spaceName.value.length > 0) {
      showPopup.style.display = '';
    } else {
      showPopup.style.display = 'none';
    }
  }
  search() {
    var inputForm = document.getElementById('search-global') as any;
    this.searchAny(inputForm.value);
    console.log(inputForm.value);
  }
  active(event: Event, key: string) {
    console.log(key);
    const isItem = document.getElementsByClassName('tablinks') as any;
    var dis = document.getElementsByClassName('tabcontent') as any;
    for (const item of isItem) {
      if (key == item.getAttribute('id')) {
        item.classList.add('active');
        for (const itemd of dis) {
          if (itemd.getAttribute('id') != key.substring(0, key.length - 1)) {
            itemd.classList.remove('this-active');
          }
          else {
            itemd.classList.add('this-active');
          }
        }
      }
      else {
        item.classList.remove('active');
      }
    }

  }
<<<<<<< HEAD
  redirect(event, id: number) {
    this.userService.getIssueDetail(id).then((res: any) => {
      this.userService.IssueDetail = res;
      this.router.navigate(['projects/view/' + res.projectID]);
    })
  }
=======
>>>>>>> c8164f3717d232480e774ceea613430b3124df52
}