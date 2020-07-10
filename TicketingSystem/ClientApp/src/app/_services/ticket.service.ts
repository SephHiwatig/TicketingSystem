import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { Helper } from "../helpers/Helper";

@Injectable({
  providedIn: 'root'
})
export class TicketService {
  constructor(private http: HttpClient) { }

  getReportFormData() {
    return this.http.get(environment.base_api + 'ticket/report-form-data', { headers: Helper.getHeaders() });
  }


}
