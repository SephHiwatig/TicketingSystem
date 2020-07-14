import { Resolve, ActivatedRouteSnapshot, Router } from "@angular/router";
import { TicketService } from "../_services/ticket.service";
import { Observable, of } from "rxjs";
import { catchError } from "rxjs/operators";
import { Injectable } from "@angular/core";

@Injectable()
export class TicketResolver implements Resolve<any> {
  constructor(private ticketService: TicketService, private router: Router) { }

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    const ticketId = route.params['id'];
    return this.ticketService.getTicketInfo(ticketId).pipe(
      catchError(() => {
        this.router.navigate(['']);
        return of(null)
      })
    );
  }
}
