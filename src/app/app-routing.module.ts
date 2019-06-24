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
import { FacebookLoginComponent } from './account/facebook-login/facebook-login.component';
import { AuthGuard } from './auth/auth.guard';
import { AuthAccountGuard } from './auth/auth-account.guard';
import { AdminComponent } from './admin/admin.component';
import { AdminAccountComponent } from './admin/account/admin-account.component';
import { MembersComponent } from './admin/members/members.component';
import { SpaceComponent } from './space/space.component';
import { AuthSpaceGuard } from './auth/auth-space.guard';

const routes: Routes = [
  {path: '', component: WwwrootComponent,  canActivate: [AuthGuard], children: [
    {path: '', redirectTo: 'dashboard', pathMatch: 'prefix'},
    {path: 'dashboard', component: BodyComponent},
    {path: 'projects', component: ProjectsComponent, children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'prefix'
      },
      {
        path: 'home/:id',
        component: HomeComponent
      },
      {
        path: 'issue/:id',
        component: IssueComponent
      },
      {
        path: 'add/:id',
        component: AddissueComponent
      },
      {
        path: 'file/:id',
        component: FileComponent
      },
      {
        path: 'setting/:id',
        component: ProjectsettingComponent
      }
    ]},
    {path: 'admin', component: AdminComponent, children: [
      {
        path: '',
        redirectTo: 'account',
        pathMatch: 'prefix'
      },
      {
        path: 'account',
        component: AdminAccountComponent
      },
      {
        path: 'members',
        component: MembersComponent
      }
    ]}
  ]
},
  {path: 'account', component: AccountComponent, canActivate: [AuthAccountGuard], children : [
    {path: '', redirectTo: 'login', pathMatch: 'prefix'},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'facebook-login', component: FacebookLoginComponent}
  ]},
  {path: 'space', component: SpaceComponent, canActivate: [AuthSpaceGuard]},
  {
    path: '**',
    redirectTo: 'dashboard'
  }
];
@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports : [RouterModule]
})
export class AppRoutingModule { }
