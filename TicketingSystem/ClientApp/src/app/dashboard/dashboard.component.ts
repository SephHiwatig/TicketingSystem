import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PaginatedResult } from '../_helpers/Pagination';
import { TicketForDashboard } from '../_models/ticketForDashboard.model';
import { Timeline } from '../_models/timeline.model';

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

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.myAssigned = data['data']['myAssigned'];
      this.recent = data['data']['recent'];
      this.resolved = data['data']['resolved'];
      this.timeline = data['data']['timeline'];
    });
  }

}
