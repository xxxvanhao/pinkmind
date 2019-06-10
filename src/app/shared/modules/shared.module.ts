import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { myFocus } from '../../directives/focus.directive';
import { SpinnerComponent } from 'src/app/spinner/spinner.component';
@NgModule({
  declarations: [myFocus, SpinnerComponent],
  imports: [
    CommonModule
  ],
  exports:      [myFocus, SpinnerComponent],
  providers:    []
})
export class SharedModule { }
