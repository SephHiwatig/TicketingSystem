import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  loginForm: FormGroup;
  registerForm: FormGroup;

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.initForms();
  }

  onLogin() {
    console.log(this.loginForm);
  }

  onRegister() {
    console.log(this.registerForm);
  }

  private initForms() {
    this.loginForm = new FormGroup({
      username: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required)
    });

    this.registerForm = new FormGroup({
      username: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(20)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(8)]),
      email: new FormControl(null, [Validators.required, Validators.email])
    });
  }
}
