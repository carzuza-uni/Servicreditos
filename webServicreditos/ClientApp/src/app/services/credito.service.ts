import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Credito } from '../servicreditos/models/credito';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CreditoService {
  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
   }

   post(credito: Credito): Observable<Credito>{
    return this.http.post<Credito>(this.baseUrl + 'api/Credito', credito)
      .pipe(
        tap(_=> this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Credito>('Registrar credito', null))
      );
  }

  get(): Observable<Credito[]>{
    return this.http.get<Credito[]>(this.baseUrl + 'api/Credito')
      .pipe(
        tap(_ => this.handleErrorService.log('Datos consultados')),
        catchError(this.handleErrorService.handleError<Credito[]>('Consulta credito', null))
      );
  }
}
