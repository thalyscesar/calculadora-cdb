import { Component } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { InvestimentoCDBModel } from '../models/InvestimentoCDBModel';
import { CDBService } from './services/CDBService.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [ ReactiveFormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  standalone: true,
})
export class AppComponent {
  cdbForm: FormGroup;
  resultado: boolean = false;
  investimentoCDBModel: InvestimentoCDBModel = new InvestimentoCDBModel(0,0)

  constructor(private fb: FormBuilder, private cdbService: CDBService) {
    this.cdbForm = this.fb.group({
      valor: ['', [Validators.required, Validators.min(1)]],
      prazo: ['', [Validators.required, Validators.min(2)]]
    });
  }

  onSubmit() : void {
    if (this.cdbForm.valid) {
      this.resultado = true;

      this.cdbService.CalcularValoresCDB(this.cdbForm.value.valor, this.cdbForm.value.prazo)
                     .subscribe((model) => this.investimentoCDBModel = model);
      
    }

    
  }
}