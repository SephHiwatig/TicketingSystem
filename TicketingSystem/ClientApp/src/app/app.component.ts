import { Component, OnInit } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { AuthService } from './_services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent implements OnInit {

  jwtHelper = new JwtHelperService();

  constructor(private authService: AuthService) { }

  ngOnInit() {
    const token = localStorage.getItem('token');
    if (token && token != null && this.jwtHelper.isTokenExpired(token)) {
      localStorage.removeItem('token');
    } else if (token && token != null && !this.jwtHelper.isTokenExpired(token)) {
       this.authService.decodedToken = this.jwtHelper.decodeToken(token);
       this.authService.isAuthorized = true;
    };
  }
}
