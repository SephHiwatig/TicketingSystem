import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "../../environments/environment";
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: "root"
})
export class AuthService {

  isAuthorized: boolean;

  constructor(private http: HttpClient) { }

  login(userForLogin: { username: string, password: string }) {
    return this.http.post(environment.base_api + "auth/login", userForLogin)
      .pipe(
        tap((res: { token: string }) => {
          if (res.token && res.token.length > 0) {
            this.isAuthorized = true;
          }
        })
      );
  }

  register(userForRegister: { username: string, password: string, email: string }) {
    return this.http.post(environment.base_api + "auth/register", userForRegister)
  }
}
