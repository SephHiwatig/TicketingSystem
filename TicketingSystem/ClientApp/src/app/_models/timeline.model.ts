export class Timeline {
  timelineId: number;
  ticketId: number;
  doneBy: number;
  action: string;
  actionDate: Date;
  doneByNavigation: { userId: number, username: string };
}
