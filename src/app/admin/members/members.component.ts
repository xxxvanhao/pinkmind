import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/user.service';
import { memberModel } from 'src/app/shared/models/MemberModel.interface';

@Component({
  selector: 'app-members',
  templateUrl: './members.component.html',
  styleUrls: ['./members.component.css']
})
export class MembersComponent implements OnInit {
  ListMember : memberModel;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
    this.getMember();

  }
  getMember(){
    this.userService.getAllMember().then((res:any)=>{
      this.ListMember = res.users;
    })
  }
}
