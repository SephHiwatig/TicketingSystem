import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng-lts/api';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.css']
})
export class TicketComponent implements OnInit {

  statuses: SelectItem[] = [];

  constructor() { }

  ngOnInit() {
    this.statuses.push({ label: 'Select Status', value: null })
  }

}
