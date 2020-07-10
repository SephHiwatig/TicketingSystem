import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ReportIssueComponent } from "./report-issue/report-issue.component";
import { ReportIssueResolver } from "./report-issue/report-issue.resolver";

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent },
  { path: 'report', component: ReportIssueComponent, resolve: {formData: ReportIssueResolver} }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
