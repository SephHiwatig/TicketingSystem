import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PaginatedResult } from '../_helpers/Pagination';
import { TicketForDashboard } from '../_models/ticketForDashboard.model';
import { Timeline } from '../_models/timeline.model';
import { DashboardService } from '../_services/dashboard.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  myAssigned: PaginatedResult<TicketForDashboard[]>;
  recent: PaginatedResult<TicketForDashboard[]>;
  resolved: PaginatedResult<TicketForDashboard[]>;
  timeline: PaginatedResult<Timeline[]>;

  constructor(private route: ActivatedRoute, private dashboardService: DashboardService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.myAssigned = data['data']['myAssigned'];
      this.recent = data['data']['recent'];
      this.resolved = data['data']['resolved'];
      this.timeline = data['data']['timeline'];
    });
  }

  onAddLeadZero(ticketId: number) {
    let res = ticketId.toString();
    while (res.length < 5) {
      res = "0" + res;
    }
    return res;
  }

  paginateMyAssigned(event) {
    const pageNumber = event.page + 1;
    const pageSize = event.rows;

    this.dashboardService.getTickets(pageNumber, pageSize, 'myassigned').subscribe(
      (res) => {
        this.myAssigned = res;
      }
    );
  }

  paginateRecents(event) {
    const pageNumber = event.page + 1;
    const pageSize = event.rows;

    this.dashboardService.getTickets(pageNumber, pageSize, 'recent').subscribe(
      (res) => {
        this.recent = res;
      }
    );
  }

  paginateResolved(event) {
    const pageNumber = event.page + 1;
    const pageSize = event.rows;

    this.dashboardService.getTickets(pageNumber, pageSize, 'resolved').subscribe(
      (res) => {
        this.resolved = res;
      }
    );
  }

  paginateTimeline(event) {
    const pageNumber = event.page + 1;
    const pageSize = event.rows;

    this.dashboardService.getTimeline(pageNumber, pageSize).subscribe(
      (res) => {
        this.timeline = res;
      }
    );
  }
}
