import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Helper } from "../helpers/Helper";
import { MessageService } from "primeng-lts/api";
import { Observable } from "rxjs";
import { Ticket } from "../_models/ticket.model";

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  constructor(private http: HttpClient, private messageService: MessageService) { }

  getReportFormData() {
    return this.http.get(environment.base_api + 'ticket/report-form-data', { headers: Helper.getHeaders() });
  }

  submitIssue(reportIssueFormData) {
    this.http.post(environment.base_api + 'ticket/report-issue', reportIssueFormData, { headers: Helper.getHeaders() })
      .subscribe(() => {
        this.messageService.add({ severity: 'success', summary: 'Success!', detail: "Your ticket has been submitted." });
      }, () => {
        this.messageService.add({ severity: 'error', summary: 'Failed', detail: "Something went wrong" });
      });
  }

  getTicketInfo(ticketId: string): Observable<Ticket> {
    return this.http.get<Ticket>(environment.base_api + 'ticket/get/' + ticketId, { headers: Helper.getHeaders() });
  }

  reassignTicket(newAssignId: number, ticketId: number) {
    return this.http.post(environment.base_api + 'ticket/reassign', { ticketId: ticketId, fieldId: newAssignId }, { headers: Helper.getHeaders() });
  }

  changeStatus(newStatusId: number, ticketId: number) {
    return this.http.post(environment.base_api + 'ticket/change-status', { ticketId: ticketId, fieldId: newStatusId }, { headers: Helper.getHeaders() });
  }
}
