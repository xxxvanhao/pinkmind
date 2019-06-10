import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccountRoutingModule } from './account-routing.module';
import { FacebookLoginComponent } from './facebook-login/facebook-login.component';
import { FormsModule, EmailValidator } from '@angular/forms';
import { SharedModule } from '../shared/modules/shared.module';
import { UserService } from '../shared/services/user.service';

@NgModule({
  declarations: [FacebookLoginComponent, EmailValidator],
  imports: [
    CommonModule,
    AccountRoutingModule,
    FormsModule,
    SharedModule
  ],
  providers:    [ UserService ]
})
export class AccountModule { }
