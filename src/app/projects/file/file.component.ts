import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
declare var jquery: any;
declare var $: any;

@Component({
  selector: 'app-file',
  templateUrl: './file.component.html',
  styleUrls: ['./file.component.css']
})
export class FileComponent implements OnInit {

  paramFileId: string;
  isProjectKey: boolean;
  constructor(private userService: UserService, private router: Router, private route: ActivatedRoute) {

  }

  ngOnInit() {

    this.getParamProjectFile();
    $('#checkAll').click(() => {
    $('.check').prop('checked', $(this).prop('checked'));
    });
    $('.add-folder-erea').hide();
    $('.add-folder-toggle').click(() => {
    $('.add-folder-erea').toggle();
    });
    $('.add-file-erea').hide();
    $('.add-file-toggle').click(() => {
    $('.add-file-erea').toggle();
    });
    $('.add-folder-cancel').click(() => {
    $('.add-folder-erea').hide();
    });

  }

  getParamProjectFile() {
    this.route.params.subscribe(params => {
      this.paramFileId = params['id'];
      this.checkProject();
      this.userService.getParamSpaceId(this.paramFileId);
      });
  }

  checkProject() {
    this.userService.getProject().then((res: any) => {
      for (const item of res) {
        if (item.id === this.paramFileId) {
          this.isProjectKey = true;
        }
      }
      if (this.isProjectKey == undefined) {
        this.router.navigate(['dashboard']);
      }
    });
  }
}

