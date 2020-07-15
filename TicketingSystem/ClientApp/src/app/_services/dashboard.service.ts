import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { Dashboard } from "../_models/dashboard.model";
import { environment } from "../../environments/environment";
import { Helper } from "../helpers/Helper";
import { map } from "rxjs/operators";
import { PaginatedResult } from "../_helpers/Pagination";
import { TicketForDashboard } from "../_models/ticketForDashboard.model";
import { Timeline } from "../_models/timeline.model";

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  constructor(private http: HttpClient) { }

  getDashboardInitialState(): Observable<any> {
    return this.http.get<Dashboard>(environment.base_api + 'dashboard', { headers: Helper.getHeaders() })
      .pipe(
        map(response => {
          const myAssigned = new PaginatedResult<TicketForDashboard[]>();
          myAssigned.result = response.myAssigned;
          myAssigned.pagination = response.myAssignedPagination;

          const recent = new PaginatedResult<TicketForDashboard[]>();
          recent.result = response.recentTickets;
          recent.pagination = response.recentTicketsPagination;

          const resolved = new PaginatedResult<TicketForDashboard[]>();
          resolved.result = response.resolved;
          resolved.pagination = response.resolvedPagination;

          const timeline = new PaginatedResult<Timeline[]>();
          timeline.result = response.timeline;
          timeline.pagination = response.timelinePagination;

          return {
            myAssigned,
            recent,
            resolved,
            timeline
          };
        })
      );
  }

  getTimeline(pageNumber: number, pageSize: number): Observable<PaginatedResult<Timeline[]>> {
    const paginatedResult: PaginatedResult<Timeline[]> = new PaginatedResult<Timeline[]>();

    let params = new HttpParams();
    params = params.append('PageNumber', pageNumber.toString());
    params = params.append('PageSize', pageSize.toString());

    return this.http.get<Timeline[]>(environment.base_api + 'dashboard/timeline', { headers: Helper.getHeaders(), params: params, observe: 'response' })
      .pipe(
        map(response => {
          paginatedResult.result = response.body;
          if (response.headers.get('Pagination') != null) {
            paginatedResult.pagination = JSON.parse(response.headers.get('Pagination'));
          }
          return paginatedResult;
        })
      );
  }
}
