import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Entretien } from '../Models/Entretien';


import { MDM } from '../Models/MDM';
import { BaseService } from './Base/base.service';

@Injectable({
  providedIn: 'root'
})
export class EntretienService extends BaseService<Entretien,number> {
  static endPoint: string = `${environment.URL}api/Entretie`;
  constructor(protected override http: HttpClient) {
    super(http,EntretienService.endPoint);
  }
  GetEntretieByCandidat(id:number): Observable<any>{
      return this.http.get<any>(`${this.baseUrl}/ByCandidat/${id}`);
  }
}
