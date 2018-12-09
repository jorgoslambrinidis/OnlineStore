import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-createitem',
  templateUrl: './createItem.component.html',
  styleUrls: ['./createItem.component.css']
})
export class CreateItemComponent implements OnInit {
  model: any = {};
  baseUrl = 'http://localhost:55186/api/values/create';

  constructor(private http: HttpClient) {}

  ngOnInit() {}

  // create item method
  onSubmit() {
    return this.http.post(this.baseUrl, this.model).subscribe(
      data => {
        console.log('POST Request is successful', data);
      },
      error => {
        console.log('Error', error);
      }
    );
  }

}
