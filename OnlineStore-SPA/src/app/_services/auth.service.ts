import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})

export class AuthService {

baseUrl = 'http://localhost:55186/api/auth/';
jwtHelper = new JwtHelperService();
decodedToken: any;

constructor(private http: HttpClient) { }

// login
login(model: any) {
  return this.http.post(this.baseUrl + 'login', model).pipe(
    map((response: any) => {
      const user = response;
      if (user) {
        localStorage.setItem('token', user.token);
        // this.decodedToken = this.jwtHelper.decodeToken(user.token);
        // console.log(this.decodedToken);
      }
    })
  );
}

loggedIn() {
  const token = localStorage.getItem('token');
  return !!token;
  // return !this.jwtHelper.isTokenExpired(token);
}

getUserClaims() {
  this.http.get(this.baseUrl + 'GetUserClaims', {headers: new HttpHeaders({'Authorization': 'Bearer ' + localStorage.getItem('token')})});
}


}
