import { Component, OnInit } from '@angular/core';
import { PersonService } from '../../services/person.service';

import { Person } from '../../models/person';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css']
})
export class PersonsComponent implements OnInit {
  persons: Person[];

  constructor(private personService: PersonService) { }

  ngOnInit() {
    this.personService.getPersons().subscribe(persons => {
      this.persons = persons;
    });
  }
  addPerson(person: Person) {
    this.personService.addPerson(person).subscribe(per => {
      this.persons.push(per);
    });
  }
}
