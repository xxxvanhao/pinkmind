import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { IssueComponent } from './issue/issue.component';
import { AddissueComponent } from './addissue/addissue.component';
import { ProjectsettingComponent } from './projectsetting/projectsetting.component';
import { ProjectsComponent } from './projects.component';
import { FileComponent } from './file/file.component';
const routes: Routes = [
  {path: 'projects', component: ProjectsComponent, children: [
    {
      path: 'home',
      component: HomeComponent
    },
    {
      path: 'issue',
      component: IssueComponent
    },
    {
      path: 'add',
      component: AddissueComponent
    },
    {
      path: 'file',
      component: FileComponent
    },
    {
      path: 'setting',
      component: ProjectsettingComponent
    }
  ]}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProjectsRoutingModule { }
