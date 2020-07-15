import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { HomeComponent } from "./home/home.component";
import { DashboardComponent } from "./dashboard/dashboard.component";
import { ReportIssueComponent } from "./report-issue/report-issue.component";
import { ReportIssueResolver } from "./report-issue/report-issue.resolver";
import { TicketComponent } from "./ticket/ticket.component";
import { TicketResolver } from "./ticket/ticket.resolver";
import { DashboardResolver } from "./dashboard/dashboard.resolver";

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'dashboard', component: DashboardComponent, resolve: { data: DashboardResolver } },
  { path: 'report', component: ReportIssueComponent, resolve: { formData: ReportIssueResolver } },
  { path: 'ticket/:id', component: TicketComponent, resolve: { ticket: TicketResolver } },
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
