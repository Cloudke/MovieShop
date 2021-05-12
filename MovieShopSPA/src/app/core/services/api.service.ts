import { Injectable } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { environment } from 'src/environment/environment';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  // Httpclient is a class=>used to communicate with api
  constructor(protected http: HttpClient) {}
  //get array of json objects
  //call only urls that get json

  getAll(path: string): Observable<any[]> {
    return this.http
      .get(`${environment.apiUrl}${path}`)
      .pipe(map((resp) => resp as any[]));
  }

  //get single json object
  getOne(path: string, id?: number) {
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
