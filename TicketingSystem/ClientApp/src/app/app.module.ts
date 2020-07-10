import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

// Routing Module
import { AppRoutingModule } from './app-routing.module';

// Developer defined components
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ReportIssueComponent } from './report-issue/report-issue.component';

// Primeng
import { MenubarModule } from 'primeng/menubar';
import { ButtonModule } from 'primeng/button';
import { DropdownModule } from 'primeng/dropdown';
import { ToastModule } from 'primeng/toast';
import { InputTextareaModule } from 'primeng/inputtextarea';
import { MessageService } from 'primeng/api';
import { InputTextModule } from 'primeng/inputtext';
import { ReportIssueResolver } from './report-issue/report-issue.resolver';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    DashboardComponent,
    ReportIssueComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MenubarModule,
    ButtonModule,
    DropdownModule,
    ReactiveFormsModule,
    ToastModule,
    InputTextareaModule,
    InputTextModule
  ],
  providers: [
    MessageService,
    ReportIssueResolver
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
