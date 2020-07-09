import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MessageService } from 'primeng-lts/components/common/messageservice';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  loginForm: FormGroup;
  registerForm: FormGroup;
  passwordRegex: string = '(?=^.{8,}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s)[0-9a-zA-Z!@#$%^&*()]*$';
  emailRegex: string = '^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$';

  constructor(private authService: AuthService,
    private messageService: MessageService,
    private router: Router) { }

  ngOnInit() {
    if (this.authService.isAuthorized) {
      this.router.navigate(['dashboard']);
    }
    this.initForms();
  }

  onLogin() {
    this.authService.login(this.loginForm.value).subscribe(
      () => {
      }, () => {
        this.messageService.add({ severity: 'error', summary: 'Failed', detail: "Invalid Username or Password" });
      }
    );
  }

  onRegister() {
    this.authService.register(this.registerForm.value).subscribe(
      (res) => {
        const userForLogin = {
          username: this.registerForm.value.username,
          password: this.registerForm.value.password
        };
        this.authService.login(userForLogin).subscribe(
          (res) => {
          }, (err) => {
            this.messageService.add({ severity: 'error', summary: 'Sorry', detail: "Something went wrong"});
          }
        );
      }, (err) => {
        this.messageService.add({ severity: 'error', summary: 'Oops!', detail: err.error });
      }
    );
  }

  private initForms() {
    this.loginForm = new FormGroup({
      username: new FormControl(null, Validators.required),
      password: new FormControl(null, Validators.required)
    });

    this.registerForm = new FormGroup({
      username: new FormControl(null, [Validators.required, Validators.minLength(6), Validators.maxLength(20)]),
      password: new FormControl(null, [Validators.required, Validators.minLength(5), Validators.maxLength(8), Validators.pattern(this.passwordRegex)]),
      email: new FormControl(null, [Validators.required, Validators.pattern(this.emailRegex)])
    });
  }
}
