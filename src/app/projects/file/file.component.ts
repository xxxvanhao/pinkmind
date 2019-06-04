import { Component, OnInit } from '@angular/core';
declare var jquery: any;
declare var $: any;

@Component({
  selector: 'app-file',
  templateUrl: './file.component.html',
  styleUrls: ['./file.component.css']
})
export class FileComponent implements OnInit {

  constructor() { }

  ngOnInit() {
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

}
