import { Component, OnInit } from '@angular/core';
import { Credito } from '../models/credito';
import { CreditoService } from 'src/app/services/credito.service';

@Component({
  selector: 'app-credito-registro',
  templateUrl: './credito-registro.component.html',
  styleUrls: ['./credito-registro.component.css']
})
export class CreditoRegistroComponent implements OnInit {
  credito: Credito;
  totalPagar: number;

  constructor(private creditoService: CreditoService) { }

  ngOnInit() {
    this.credito = new Credito();
  }

  add(){
    this.totalPagar = this.credito.calcularTotalPagar();
    
    this.creditoService.post(this.credito).subscribe(p => {
      if (!p) {
        //this.credito.identificacion = '';
        //this.credito.nombre = '';
        //this.credito.capitalInicial = null;
        //this.credito.tasaInteres = null;
        //this.credito.tiempoDuracion = null;
        alert('Registro realizado con exito!');
      }
    });
  }

}
