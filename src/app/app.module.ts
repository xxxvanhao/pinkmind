import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { BodyComponent } from './dashboard/body.component';
import { FooterComponent } from './footer/footer.component';
import { AppRoutingModule } from './app-routing.module';
import { ProjectsModule } from './projects/projects.module';
import { ProjectsComponent } from './projects/projects.component';
import { HomeComponent } from './projects/home/home.component';
import { IssueComponent } from './projects/issue/issue.component';
import { AddissueComponent } from './projects/addissue/addissue.component';
import { ProjectsettingComponent } from './projects/projectsetting/projectsetting.component';
import { MenuComponent } from './projects/menu/menu.component';
import { AccountComponent } from './account/account.component';
import { LoginComponent } from './Account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { OrganizationComponent } from './organization/organization.component';
import { ProFileComponent } from './organization/pro-file/pro-file.component';
import { SecurityComponent } from './organization/security/security.component';
import { ChangePasswordComponent } from './organization/change-password/change-password.component';
import { GenaralComponent } from './projects/projectsetting/genaral/genaral.component';
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';
import { WwwrootComponent } from './wwwroot/wwwroot.component';
import { SocialLoginModule, AuthServiceConfig } from 'angularx-social-login';
import { GoogleLoginProvider, FacebookLoginProvider } from 'angularx-social-login';


const config = new AuthServiceConfig([
  {
    id: GoogleLoginProvider.PROVIDER_ID,
    provider: new GoogleLoginProvider('302915156991-khminqnb8g314ul54pncrgka89e6j6bi.apps.googleusercontent.com')
  },
  {
    id: FacebookLoginProvider.PROVIDER_ID,
    provider: new FacebookLoginProvider('Facebook-App-Id')
  }
]);
export function provideConfig() {
  return config;
}

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
    MenuComponent,
    AccountComponent,
    LoginComponent,
    RegisterComponent,
    OrganizationComponent,
    ProFileComponent,
    SecurityComponent,
    ChangePasswordComponent,
    GenaralComponent,
    WwwrootComponent,
  ],
  imports: [
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    ProjectsModule,
    FormsModule,
    HttpClientModule,
    SocialLoginModule
  ],
  providers: [
    {
      provide: AuthServiceConfig,
      useFactory: provideConfig
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
