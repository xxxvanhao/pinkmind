import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { SharedModule } from '../shared/modules/shared.module';
import { FormsModule } from '@angular/forms';
import { DashboardService } from './services/dashboard.service';
import { AuthGuard } from '../auth/auth.guard';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    SharedModule,
    FormsModule
  ],
  exports: [ ],
  providers: [AuthGuard, DashboardService]
})
export class DashboardModule { }
