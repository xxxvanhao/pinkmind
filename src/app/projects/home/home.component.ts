import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgStyle } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{

  paramHomeId: string;
  constructor(private userService: UserService, private route: ActivatedRoute) { 
  }

  ngOnInit() {
    this.getParamProjectHome();
  }
  getParamProjectHome() {
    this.route.params.subscribe(params => {
      this.paramHomeId = params['id'];
      this.userService.getParamSpaceId(this.paramHomeId);
      });
  }
}
