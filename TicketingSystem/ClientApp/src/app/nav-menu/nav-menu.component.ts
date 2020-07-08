import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng-lts/components/common/selectitem';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor(public authService: AuthService) { }

  ngOnInit() {

  }
}
