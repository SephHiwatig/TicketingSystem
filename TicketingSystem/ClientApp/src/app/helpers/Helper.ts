import { HttpHeaders } from "@angular/common/http";

export class Helper {
  public static getHeaders() {
    let headers = new HttpHeaders();
    headers = headers.set('Content-Type', 'application/json');
    const token = localStorage.getItem('token');
    if (!token || token === '') { return headers; }
    const tokenValue = 'Bearer ' + token;
    headers = headers.set('Authorization', tokenValue);
    return headers;
  }
}
