import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
//import { PersonaConsultaComponent } from './Pulsacion/persona-consulta/persona-consulta.component';
//import { PersonaRegistroComponent } from './Pulsacion/persona-registro/persona-registro.component';
import { CreditoConsultaComponent } from './servicreditos/credito-consulta/credito-consulta.component';
import { CreditoRegistroComponent } from './servicreditos/credito-registro/credito-registro.component';

const routes: Routes = [
  {
    path: 'creditoConsulta',
    component: CreditoConsultaComponent
  },
  {
    path: 'creditoRegistro',
    component: CreditoRegistroComponent
  }
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }
