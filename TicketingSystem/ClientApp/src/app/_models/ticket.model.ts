import { Field } from "./field.model";
import { Comment } from "./comment.model";

export class Ticket {
  ticket: {
    ticketId: number;
    status: {statusId: number, description: string};
    assignedToNavigation: { userId: number, username: string };
    dateCreated: Date;
    Title: string;
    summary: string;
    projectName: string;
    reportedBy: string;
    priority: string;
    severity: string;
    comments: Comment;
  };

  status: { statusId: number, description: string }[];
  users: { userId: number, username: string }[];
}


