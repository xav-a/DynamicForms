import { Component, Input, OnInit } from '@angular/core';
import { Form } from '../../models/form';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent {

  @Input() context!: Form;

  // Mostrar los campos del formulario
  display: boolean = false;

}
