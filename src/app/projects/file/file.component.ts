import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpHeaders } from '@angular/common/http';
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

    window.onload = () => {
      document.getElementById('uploader').onsubmit = () => {
          const formdata = new FormData(); // FormData object
          const fileInput = document.getElementById('fileInput') as any;
          // Iterating through each files selected in fileInput
          console.log('hihi');
          for (let i = 0; i < fileInput.files.length; i++) {
              // Appending each file to FormData object
              formdata.append(fileInput.files[i].name, fileInput.files[i]);
          }
          //Creating an XMLHttpRequest and sending
          var xhr = new XMLHttpRequest();
          const authToken = localStorage.getItem('auth_token');
          xhr.open('POST', 'http://localhost:5000/api/FileUpload');
          xhr.setRequestHeader('Authorization', `Bearer ${authToken}`);
          xhr.send(formdata);
          xhr.onreadystatechange = () => {
              if (xhr.readyState == 4 && xhr.status == 200) {
                  alert(xhr.responseText);
              }
          };
          return false;
      };
  };

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

