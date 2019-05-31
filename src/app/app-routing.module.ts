import { NgModule } from '@angular/core';
import {Routes, RouterModule } from '@angular/router';
import { BodyComponent } from './dashboard/body.component';
import { ProjectsComponent } from './projects/projects.component';

const routes: Routes = [
  {path: 'dashboard', component: BodyComponent},
  {path: 'projects', component: ProjectsComponent}
];
@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports : [RouterModule]
})
export class AppRoutingModule { }
