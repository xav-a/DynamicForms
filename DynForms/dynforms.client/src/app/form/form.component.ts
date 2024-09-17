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
  public display: boolean = false;

  public toggleDisplay() {
    this.display = !this.display;
    console.log(this.display);
  }

}
