import { Component, OnInit, Input } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpHeaders, HttpUrlEncodingCodec } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { FileUpload } from 'src/app/shared/models/fileupload.interface';
import { empty } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { getFileNameFromResponseContentDisposition, saveFile } from 'src/app/shared/services/file-download-helper';
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
  paramFile: string;
  paramFilePath: string;
  iBackFolder: number;
  BackFolder: string;
  fileUpload: FileUpload;
  constructor(private toastr: ToastrService, private userService: UserService, private router: Router, private route: ActivatedRoute) {

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
    setTimeout(() => this.getFileDetails(), 1000);
  }

  getParamProjectFile() {
    const seft = this;
    this.route.params.subscribe(params => {
      this.paramFileId = params.id;
      this.checkProject();
      this.paramFile = this.getParaFileByName('path', null);
      this.paramFilePath = this.paramFile == '' ? '' : `${this.paramFile}/`;
      this.iBackFolder = this.paramFile.lastIndexOf('/');
      this.BackFolder = this.iBackFolder == -1 ? '' : `?path=${this.paramFile.substring(0, this.iBackFolder)}`;
      this.userService.getParamSpaceId(this.paramFileId);
      });
  }

  getParaFileByName(name, url) {
    if (!url) { url = window.location.href; }
    name = name.replace(/[\[\]]/g, '\\$&');
    const regex = new RegExp('[?&#]' + name + '(=([^&#]*)|&|#|$)'), results = regex.exec(url);
    if (!results) { return ''; }
    if (!results[2]) { return ''; }
    return decodeURIComponent(results[2].replace(/\+/g, ' '));
  }

  getFileDetails() {
    const path = `${this.userService.userDetails.spaceID}/${this.paramFileId}/${this.paramFile}`;
    this.userService.getFile(path);
  }

  folderSubmit(folderForm: NgForm) {
    this.fileUpload = {
      folderPath: `${this.userService.userDetails.spaceID}/${this.paramFileId}/${this.paramFile}`,
      filePath: folderForm.value.folderPath,
      projectID: this.paramFileId,
    };
    this.userService.postFolder(this.fileUpload).subscribe(
      res => {
        this.toastr.success('Successful!', 'Add Folder');
        folderForm.resetForm();
        return true;
      },
      err => {
        this.toastr.error('Error!', `${err.message}`) ;
        folderForm.resetForm();
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

  UploadFile() {

    const pathFile = `${this.userService.userDetails.spaceID}/${this.paramFileId}/${this.paramFile}`;
    const pathEncode = encodeURIComponent(pathFile);
    const formdata = new FormData(); // FormData object
    const fileInput = document.getElementById('fileInput') as any;
    // Iterating through each files selected in fileInput
    for (let i = 0; i < fileInput.files.length; i++) {
        // Appending each file to FormData object
        formdata.append(fileInput.files[i].name, fileInput.files[i]);
    }
    // Creating an XMLHttpRequest and sending
    var xhr = new XMLHttpRequest();
    const authToken = localStorage.getItem('auth_token');
    xhr.open('POST', `http://localhost:5000/api/FileUpload/pathproject/${pathEncode}/${this.userService.spaceId}`);
    xhr.setRequestHeader('Authorization', `Bearer ${authToken}`);
    xhr.send(formdata);
    xhr.onreadystatechange = () => {
        if (xhr.readyState == 4 && xhr.status == 200) {
            alert(xhr.responseText);
        }
    };
    return false;
  }

  checkboxChecked() {
    const getAll = document.getElementById('checkAll') as any;
    const checkFile = document.getElementsByClassName('checkFile') as any;
    if (getAll.checked === true) {
      for (const item of checkFile) {
        item.checked = true;
      }
    } else {
      for (const item of checkFile) {
        item.checked = false;
      }
    }
  }

  async downloadFile() {
    let haveCheck = false;
    const checkFile = document.getElementsByClassName('checkFile') as any;
    for (const item of checkFile) {
      if (item.checked === true) {
        haveCheck = true;
      }
    }
    if (!haveCheck) {
      this.toastr.warning('Please pick some thing!', 'Download file');
      return false;
    }
    for (const item of checkFile) {
      if (item.checked === true) {
        const path = `image/imageproject/${this.userService.userDetails.spaceID}/${this.paramFileId}/${this.paramFilePath}${item.value}`;
       await this.userService.downloadFileProject(path).subscribe((res: any) => {
          console.log(res);
          saveFile(res, `${item.value}`, res.type );
          // const blob = new Blob([res], { type: res.type});
          // const url = window.URL.createObjectURL(blob);
          // const pwa = window.open(url);
          // if (!pwa || pwa.closed || typeof pwa.closed == undefined) {
          //   alert( 'Please disable your Pop-up blocker and try again.');
          // }
        });
      }
    }
  }

  deleteFile() {
    let haveCheck = false;
    const checkFile = document.getElementsByClassName('checkFile') as any;
    for (const item of checkFile) {
      if (item.checked === true) {
        haveCheck = true;
      }
    }
    if (!haveCheck) {
      this.toastr.warning('Please pick some thing!', 'Delete file');
      return false;
    }
    for (const item of checkFile) {
      if (item.checked === true) {
        return true;
      }
    }
  }

}

