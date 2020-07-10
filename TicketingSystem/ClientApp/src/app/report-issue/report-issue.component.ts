import { Component, OnInit } from '@angular/core';
import { SelectItem } from 'primeng-lts/api';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-report-issue',
  templateUrl: './report-issue.component.html',
  styleUrls: ['./report-issue.component.css']
})
export class ReportIssueComponent implements OnInit {

  projects: SelectItem[] = [];
  developers: SelectItem[] = [];
  severities: SelectItem[] = [];
  priorities: SelectItem[] = [];
  reportIssueForm: FormGroup;

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
      this.projects.push({ label: 'Select Project', value: null });
      data['formData']['projects'].forEach(proj => {
        this.projects.push({ label: proj.projectName, value: proj.projectId });
      });
      this.developers.push({ label: 'Select User', value: null });
      data['formData']['users'].forEach(user => {
        this.developers.push({ label: user.username, value: user.userId });
      });
      this.severities.push({ label: 'Select Severity', value: null });
      data['formData']['severities'].forEach(severity => {
        this.severities.push({ label: severity.description, value: severity.severityId });
      });
      this.priorities.push({ label: 'Select Priority', value: null });
      data['formData']['priorities'].forEach(priority => {
        this.priorities.push({ label: priority.description, value: priority.priorityId });
      });
    })

    this.initReportIssueForm();
  }

  onSubmitRerpotIssueForm() {
    console.log(this.reportIssueForm);
  }

  private initReportIssueForm() {
    this.reportIssueForm = new FormGroup({
      project: new FormControl(null, Validators.required),
      assignTo: new FormControl(null, Validators.required),
      severity: new FormControl(null, Validators.required),
      priority: new FormControl(null, Validators.required),
      title: new FormControl(null, [Validators.required, Validators.maxLength(255)]),
      summary: new FormControl(null, [Validators.required, Validators.maxLength(255)]),
      comment: new FormControl(null, Validators.maxLength(255))
    });
  }
}
