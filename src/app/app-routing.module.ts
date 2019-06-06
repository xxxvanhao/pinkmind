import { NgModule } from '@angular/core';
import {Routes, RouterModule } from '@angular/router';
import { BodyComponent } from './dashboard/body.component';
import { ProjectsComponent } from './projects/projects.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { WwwrootComponent } from './wwwroot/wwwroot.component';
import { HomeComponent } from './projects/home/home.component';
import { IssueComponent } from './projects/issue/issue.component';
import { FileComponent } from './projects/file/file.component';
import { AddissueComponent } from './projects/addissue/addissue.component';
import { ProjectsettingComponent } from './projects/projectsetting/projectsetting.component';

const routes: Routes = [
  {path: '', component: WwwrootComponent, children: [
    {path: '', redirectTo: 'dashboard', pathMatch: 'prefix'},
    {path: 'dashboard', component: BodyComponent},
    {path: 'projects', component: ProjectsComponent, children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'prefix'
      },
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
  ]
},
  {path: 'account', component: AccountComponent, children : [
    {path: '', redirectTo: 'login', pathMatch: 'prefix'},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent}
  ]},
  {
    path: '**',
    redirectTo: 'dashboard'
  },
];
@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports : [RouterModule]
})
export class AppRoutingModule { }
