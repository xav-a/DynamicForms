import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Form } from '../models/form';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forms: Form[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForms();
  }

  getForms() {
    this.http.get<Form[]>('/api/form').subscribe(
      (result) => {
        this.forms = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'dynforms.client';
}
