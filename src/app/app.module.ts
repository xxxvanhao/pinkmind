import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
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
import { FroalaEditorModule, FroalaViewModule } from 'angular-froala-wysiwyg';

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
    MenuComponent
  ],
  imports: [
    FroalaEditorModule.forRoot(),
    FroalaViewModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    ProjectsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
