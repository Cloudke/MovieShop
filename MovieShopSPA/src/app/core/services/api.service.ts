import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  // Httpclient is a class=>used to communicate with api,make httpRequest
  //http is the name, HttpClient is the Class
  constructor(protected http: HttpClient) {}
  //get array of json objects
  //call only urls that get json

  getList(path: string): Observable<any[]> {
    return this.http
      .get(`${environment.apiUrl}${path}`)
      .pipe(map((resp) => resp as any[]));
  }

  //get single json object
  getOne(path: string, id?: number):Observable<any> {
    // return this.http
    //   .get(`${environment.apiUrl}${path}`)
    //   .pipe(map((resp) => resp as any));

    return this.http
      .get(`${environment.apiUrl}${path}` + id)
      .pipe(map((resp) => resp as any));
  }

  //post sth
  create() {}
  //put
  update() {}
  //delete
  delete() {}
}
