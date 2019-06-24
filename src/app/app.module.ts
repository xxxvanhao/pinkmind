import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BodyComponent } from './dashboard/body.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from './app-routing.module';
import { ProjectsComponent } from './projects/projects.component';
import { HomeComponent } from './projects/home/home.component';
import { IssueComponent } from './projects/issue/issue.component';
import { AddissueComponent } from './projects/addissue/addissue.component';
import { ProjectsettingComponent } from './projects/projectsetting/projectsetting.component';
import { AccountComponent } from './account/account.component';
import { WwwrootModule } from './wwwroot/wwwroot.module';
import { WwwrootComponent } from './wwwroot/wwwroot.component';
import { FileComponent } from './projects/file/file.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { MenuComponent } from './projects/menu/menu.component';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HttpXhrBackend, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { ConfigService } from './shared/utils/config.service';
import { AuthenticateXHRBackend } from './authenticate-xhr.backend';
import { SpinnerComponent } from './spinner/spinner.component';
import { FacebookLoginComponent } from './account/facebook-login/facebook-login.component';
import { AuthGuard } from './auth/auth.guard';
import { FacebookAuthComponent } from './facebook-auth/facebook-auth.component';
import { AuthAccountGuard } from './auth/auth-account.guard';
import { AuthSpaceGuard } from './auth/auth-space.guard';
import { AdminComponent } from './admin/admin.component';
import { AdminAccountComponent } from './admin/account/admin-account.component';
import { MembersComponent } from './admin/members/members.component';
import { SpaceComponent } from './space/space.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { ProjectsRoutingModule } from './projects/projects-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    BodyComponent,
    FooterComponent,
    ProjectsComponent,
    HomeComponent,
    IssueComponent,
    AddissueComponent,
    ProjectsettingComponent,
    AccountComponent,
    WwwrootComponent,
    FileComponent,
    LoginComponent,
    RegisterComponent,
    MenuComponent,
    SpinnerComponent,
    FacebookLoginComponent,
    FacebookAuthComponent,
    AdminComponent,
    AdminAccountComponent,
    MembersComponent,
    SpaceComponent
  ],
  imports: [
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    BrowserAnimationsModule,
    ToastrModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    ProjectsRoutingModule,
    WwwrootModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ConfigService, {
    provide: [HttpXhrBackend, HTTP_INTERCEPTORS],
    useClass: AuthenticateXHRBackend
  }, AuthGuard, AuthAccountGuard, AuthSpaceGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
