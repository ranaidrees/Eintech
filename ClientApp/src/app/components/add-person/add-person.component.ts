import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.css']
})
export class AddPersonComponent implements OnInit {
  @Output() addPerson: EventEmitter<any> = new EventEmitter();

  title: string;
  form: FormGroup;

  constructor(private formBuilder: FormBuilder) {
    this.form = formBuilder.group(
      {
        firstName: ['', [Validators.required]],
        lastName: ['', [Validators.required]]
      }
    );
   }

  ngOnInit() {
  }

  onSubmit() {
    const person = {
      firstName: this.form.get('firstName').value,
      lastName: this.form.get('lastName').value,
      created: new Date(Date.parse(Date()))
    };
    this.addPerson.emit(person);
  }
}
