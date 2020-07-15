export class Timeline {
  timelineId: number;
  ticketId: number;
  doneBy: number;
  action: string;
  actionDate: Date;
  DoneByNavigation: { userId: number, username: string };
}
