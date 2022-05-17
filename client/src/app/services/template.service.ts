import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MDM } from '../Models/MDM';
import { Template, Templatecommente, TemplateDTO } from '../Models/Template';
import { BaseService } from './Base/base.service';

@Injectable({
  providedIn: 'root'
})
export class TemplateService extends BaseService<Template,number> {
  static endPoint: string = `${environment.URL}api/Template`;
  constructor(protected override http: HttpClient) {
    super(http,TemplateService.endPoint);
  }



  UpdateNote(id: string,body:TemplateDTO){
    
    return this.http.put<TemplateDTO>(`${TemplateService.endPoint}/Note/${id}`, body);
   }


   UpdateCommente(id: string,value: string){
     debugger;
    let body= new Templatecommente();
    body.Commente=value;
    return this.http.put(`${TemplateService.endPoint}/Commente/${id}`, body);
   }
}
