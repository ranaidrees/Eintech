import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Person } from '../models/person';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  personsUrl = 'http://localhost:51000/api/person';
  personsLimit = '?_limit=5';

  constructor(private http: HttpClient) { }

  getPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(`${this.personsUrl}${this.personsLimit}`);
  }

  addPerson(person: Person): Observable<Person> {
    return this.http.post<Person>(this.personsUrl, person, httpOptions);
  }
}
