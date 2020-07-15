import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Helper } from "../helpers/Helper";
import { MessageService } from "primeng-lts/api";
import { Observable } from "rxjs";
import { Ticket } from "../_models/ticket.model";
import { Comment } from "../_models/comment.model";
import { Router } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  constructor(private http: HttpClient, private messageService: MessageService,
    private router: Router) { }

  getReportFormData() {
    return this.http.get(environment.base_api + 'ticket/report-form-data', { headers: Helper.getHeaders() });
  }

  submitIssue(reportIssueFormData) {
    this.http.post(environment.base_api + 'ticket/report-issue', reportIssueFormData, { headers: Helper.getHeaders() })
      .subscribe(() => {
        this.router.navigate(['/dashboard']);
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

  addComment(comment: Comment): Observable<Comment> {
    return this.http.post<Comment>(environment.base_api + 'ticket/add-comment', comment, { headers: Helper.getHeaders() });
  }
}
