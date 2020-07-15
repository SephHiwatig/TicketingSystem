import { Field } from "./field.model";

export class Comment {
  comment: string;
  commentDate: Date;
  user: { userId: number, username: string };
  ticketId: number;
  userId: number;
}
