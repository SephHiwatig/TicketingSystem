import { Component, OnInit } from '@angular/core';
import { SelectItem, MessageService } from 'primeng-lts/api';
import { ActivatedRoute } from '@angular/router';
import { Ticket } from '../_models/ticket.model';
import { AuthService } from '../_services/auth.service';
import { TicketService } from '../_services/ticket.service';
import { Comment } from '../_models/comment.model';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {

  statuses: SelectItem[] = [];
  users: SelectItem[] = [];
  ticketInfo: Ticket;

  newStatusId: number;
  newAssignId: number;
  newComment: string;

  constructor(private route: ActivatedRoute,
    public authService: AuthService,
    private ticketService: TicketService,
    private messageService: MessageService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.ticketInfo = data['ticket'];
      this.newAssignId = this.ticketInfo.ticket.assignedToNavigation.userId;
      this.newStatusId = this.ticketInfo.ticket.status.statusId;

      this.ticketInfo.users.forEach(user => {
        const newUser = { label: user.username, value: user.userId };
        this.users.push(newUser);
      });

      this.ticketInfo.status.forEach(stat => {
        const newStatus = { label: stat.description, value: stat.statusId };
        this.statuses.push(newStatus);
      });
    })
  }

  onChangeStatus() {
    const statusUnchanged = this.newStatusId === this.ticketInfo.ticket.status.statusId;
    const invalidUser = this.authService.userid !== this.ticketInfo.ticket.assignedToNavigation.userId;
    if (statusUnchanged || invalidUser) {
      return;
    }

    this.ticketService.changeStatus(this.newStatusId, this.ticketInfo.ticket.ticketId).subscribe(
      () => {
        this.messageService.add({ severity: 'success', summary: 'Success', detail: "Status updated" });
      }, () => {
        this.messageService.add({ severity: 'error', summary: 'Failed', detail: "Something went wrong" });
      }
    );
  }

  onReassign() {
    const assignmentUnchanged = this.newAssignId === this.ticketInfo.ticket.assignedToNavigation.userId;
    const invalidUser = this.authService.userid !== this.ticketInfo.ticket.assignedToNavigation.userId;
    if (assignmentUnchanged || invalidUser) {
      return;
    }

    this.ticketService.reassignTicket(this.newAssignId, this.ticketInfo.ticket.ticketId).subscribe(
      () => {
        const newAssigned = this.ticketInfo.users.find(x => x.userId === this.newAssignId);
        this.ticketInfo.ticket.assignedToNavigation = newAssigned;
        this.messageService.add({ severity: 'success', summary: 'Success', detail: "Ticket reassigned" });
      }, () => {
        this.messageService.add({ severity: 'error', summary: 'Failed', detail: "Something went wrong" });
      }
    );
  }

  onAddComment() {
    if (!this.newComment || this.newComment === "") {
      return;
    }

    const comment = new Comment();
    comment.comment = this.newComment;
    comment.commentDate = new Date(),
    comment.ticketId = this.ticketInfo.ticket.ticketId;
    comment.userId = this.authService.userid;
    this.ticketService.addComment(comment).subscribe(
      (res) => {
        this.ticketInfo.ticket.comments.unshift(res);
      }, () => {
        this.messageService.add({ severity: 'error', summary: 'Failed', detail: "Something went wrong" });
      }
    );
  }
}
