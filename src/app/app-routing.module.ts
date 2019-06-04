import { NgModule } from '@angular/core';
import {Routes, RouterModule } from '@angular/router';
import { BodyComponent } from './dashboard/body.component';
import { ProjectsComponent } from './projects/projects.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
const routes: Routes = [
  {path: '', redirectTo: 'account', pathMatch: 'full'},
  {path: 'account', component: AccountComponent, children : [
    {path: '', redirectTo: 'login', pathMatch: 'prefix'},
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent}
  ]},
  {path: 'dashboard', component: BodyComponent},
  {path: 'projects', component: ProjectsComponent}
];
@NgModule({
  declarations: [],
  imports: [RouterModule.forRoot(routes)],
  exports : [RouterModule]
})
export class AppRoutingModule { }
