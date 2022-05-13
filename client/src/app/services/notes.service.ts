import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

import { MDM } from '../Models/MDM';
import { Notes } from '../Models/notes';
import { BaseService } from './Base/base.service';

@Injectable({
  providedIn: 'root'
})
export class notesService extends BaseService<Notes,number> {
  static endPoint: string = `${environment.URL}api/Notes`;
  constructor(protected override http: HttpClient) {
    super(http,notesService.endPoint);
  }
}
