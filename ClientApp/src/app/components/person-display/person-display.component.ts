import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { PersonService } from '../../services/person.service';

import { Person } from '../../models/person';

@Component({
  selector: 'app-person-display',
  templateUrl: './person-display.component.html',
  styleUrls: ['./person-display.component.css']
})
export class PersonDisplayComponent implements OnInit {
  @Input() person: Person;

  constructor(private personService: PersonService) { }

  ngOnInit() {
  }
}
