import { TicketForDashboard } from "./ticketForDashboard.model";
import { Timeline } from "./timeline.model";
import { Pagination } from "../_helpers/Pagination";

export class Dashboard {
  myAssigned: TicketForDashboard[];
  recentTickets: TicketForDashboard[];
  resolved: TicketForDashboard[];
  timeline: Timeline[];

  myAssignedPagination: Pagination;
  recentTicketsPagination: Pagination;
  resolvedPagination: Pagination;
  timelinePagination: Pagination;
}
