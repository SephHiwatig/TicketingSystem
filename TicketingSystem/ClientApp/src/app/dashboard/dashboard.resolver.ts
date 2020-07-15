import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Dashboard } from "../_models/dashboard.model";
import { Observable } from "rxjs";
import { DashboardService } from "../_services/dashboard.service";

@Injectable()
export class DashboardResolver implements Resolve<any> {
  constructor(private dashboardService: DashboardService) { }
  resolve(route: ActivatedRouteSnapshot): Observable<Dashboard> {
    return this.dashboardService.getDashboardInitialState();
  }
}
