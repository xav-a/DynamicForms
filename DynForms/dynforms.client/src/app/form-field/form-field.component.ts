import { Component, Input, OnInit } from '@angular/core';
import { Field } from '../../models/form-field';

@Component({
  selector: 'app-form-field',
  templateUrl: './form-field.component.html',
  styleUrl: './form-field.component.css'
})
export class FormFieldComponent implements OnInit {
  @Input()
  field!: Field;

    ngOnInit(): void {
        throw new Error('Method not implemented.');
    }

}
