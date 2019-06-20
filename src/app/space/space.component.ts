import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/services/user.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { UserDetails } from '../shared/models/userDetails.interface';

@Component({
  selector: 'app-space',
  templateUrl: './space.component.html',
  styleUrls: ['./space.component.css']
})
export class SpaceComponent implements OnInit {

  constructor(private userService: UserService, private router: Router, private toastr: ToastrService) { }
  userDetails: UserDetails;
  ngOnInit() {

  }
  onSubmit(form: NgForm) {
    this.userService.postSpace(form.value).subscribe(
      res => {
        this.toastr.success('Successful!', 'Register Space');
        form.resetForm();
        this.router.navigate(['dashboard']);
      },
      err => {
        this.toastr.error('Failed!', 'Register Space');
        form.resetForm();
      }
    );
  }
}
