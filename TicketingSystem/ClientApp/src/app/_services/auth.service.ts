import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { tap } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Router } from "@angular/router";
import { MessageService } from "primeng-lts/api";

@Injectable({
  providedIn: "root"
})
export class AuthService {

  jwtHelper = new JwtHelperService();
  isAuthorized: boolean;
  username: string;
  userid: number;


  constructor(private http: HttpClient, private router: Router, private messageService: MessageService) { }

  login(userForLogin: { username: string, password: string }) {
    return this.http.post(environment.base_api + "auth/login", userForLogin)
      .pipe(
        tap((res: { token: string }) => {
          if (res.token && res.token.length > 0) {
            this.isAuthorized = true;
            localStorage.setItem('token', res.token);
            const { nameid, unique_name } = this.jwtHelper.decodeToken(res.token);
            this.userid = nameid;
            this.username = unique_name;
            this.messageService.add({ severity: 'success', summary: 'Login successful', detail: "Welcome " + unique_name });
            this.router.navigate(['dashboard']);
          }
        })
      );
  }

  logout() {
    localStorage.clear();
    this.username = undefined;
    this.userid = undefined;
    this.isAuthorized = false;
    this.router.navigate(['']);
  }

  register(userForRegister: { username: string, password: string, email: string }) {
    return this.http.post(environment.base_api + "auth/register", userForRegister)
  }
}
