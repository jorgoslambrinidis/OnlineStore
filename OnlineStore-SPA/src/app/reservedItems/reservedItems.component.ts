import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-reserveditems',
  templateUrl: './reservedItems.component.html',
  styleUrls: ['./reservedItems.component.css']
})
export class ReservedItemsComponent implements OnInit {
  items: any;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getReservedItems();
  }

  getReservedItems() {
    this.http.get('http://localhost:55186/api/values/reserved').subscribe(response => {
      this.items = response;
    }, error => {
      console.log(error);
    });

  }
}
