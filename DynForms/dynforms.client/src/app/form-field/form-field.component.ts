import { Component, Input, OnInit } from '@angular/core';
import { Field } from '../../models/form-field';

@Component({
  selector: 'app-form-field',
  templateUrl: './form-field.component.html',
  styleUrl: './form-field.component.css'
})
export class FormFieldComponent implements OnInit {
  @Input()
  context!: Field;

  public columnWidth: string = "col";
  public fieldId: string | undefined;

  ngOnInit(): void {
    this.fieldId = `field-${this.context.id}`;

    let width = this.context.width;
    if (width && width > 0) this.columnWidth = `col-${width}`;

  }

}
