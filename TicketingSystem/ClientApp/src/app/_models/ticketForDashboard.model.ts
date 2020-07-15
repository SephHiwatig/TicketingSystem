import { Project } from "./project.model";

export class TicketForDashboard {
  ticketId: number;
  project: Project;
  title: string;
  dateCreated: Date;
  priorityId: number;
}
