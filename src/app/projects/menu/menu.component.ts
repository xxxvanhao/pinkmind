import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
declare var jquery: any;
declare var $: any;
@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private userService: UserService) { }

  ngOnInit() {
$('[data-toggle="tooltip"]').tooltip();
    // Hide submenus
$('#body-row .collapse').collapse('hide');
// Collapse/Expand icon
$('#collapse-icon').addClass('fa-angle-double-left');
// Collapse click
$('[data-toggle=sidebar-colapse]').click(() =>
    SidebarCollapse()
);
function SidebarCollapse() {
    $('.menu-collapsed').toggleClass('d-none');
    $('#sidebar-container').toggleClass('sidebar-expanded sidebar-collapsed');
    // Treating d-flex/d-none on separators with title
    const SeparatorTitle = $('.sidebar-separator-title');
    if ( SeparatorTitle.hasClass('d-flex') ) {
        SeparatorTitle.removeClass('d-flex');
    } else {
        SeparatorTitle.addClass('d-flex');
    }
    // Collapse/Expand icon
    $('#collapse-icon').toggleClass('fa-angle-double-x-double-right');
    }
function myFunction(x) {
    if (x.matches) {
      SidebarCollapse();
    }
}
const x = window.matchMedia('(max-width: 760px)');
myFunction(x);
x.addListener(myFunction);
  }
}
