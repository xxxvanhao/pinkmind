import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { AuthGuard } from '../auth.guard';
import { SharedModule } from '../shared/modules/shared.module';
import { FormsModule } from '@angular/forms';
import { DashboardService } from './services/dashboard.service';

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
