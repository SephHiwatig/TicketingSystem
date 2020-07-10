import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { Injectable } from "@angular/core";
import { TicketService } from "../_services/ticket.service";
import { Observable } from "rxjs";


@Injectable()
export class ReportIssueResolver implements Resolve<any> {

  constructor(private ticketService: TicketService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    return this.ticketService.getReportFormData();
  }
}
