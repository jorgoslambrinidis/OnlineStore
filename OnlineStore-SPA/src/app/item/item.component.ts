import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-item',
  templateUrl: './item.component.html',
  styleUrls: ['./item.component.css']
})
export class ItemComponent implements OnInit {

  items: any;
  baseUrl = 'http://localhost:55186/api/values/';

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getItems();
  }

  getItems() {
    this.http.get('http://localhost:55186/api/values/items').subscribe(response => {
      this.items = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
  }

  buyItem(id: any) {
    this.http.post(this.baseUrl + 'reserve', id).subscribe(
      data => {
        console.log('POST Request is successful', data);
      },
      error => {
        console.log('Error', error);
      }
    );
  }

}
