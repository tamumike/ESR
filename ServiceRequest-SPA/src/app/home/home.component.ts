import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private http: HttpClient) { }

  ngOnInit() {
    // this.getValues();
  }

  getValues() {
    this.http.get('http://localhost:5000/ServiceRequests').subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
  }


}
