import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { InvestimentoCDBModel } from '../../models/InvestimentoCDBModel';

@Injectable({
    providedIn: 'root',

  })

 export class CDBService{

    private apiUrl = 'https://localhost:44396/CDB/CalcularValores'

    constructor(private http: HttpClient) {
    }

    CalcularValoresCDB(valor: number, prazo: number): Observable<InvestimentoCDBModel> {
        return this.http.post<InvestimentoCDBModel>(this.apiUrl, { valor, mes: prazo });
    }
 } 