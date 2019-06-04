import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectsRoutingModule } from './projects-routing.module';
import { ViewComponent } from './issue/view/view.component';
import { FileComponent } from './file/file.component';

@NgModule({
  declarations: [ViewComponent, FileComponent],
  imports: [
    CommonModule,
    ProjectsRoutingModule
  ]
})
export class ProjectsModule { }
