import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { HttpEventType, HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { inputs } from '@syncfusion/ej2-angular-pdfviewer/src/pdfviewer/pdfviewer.component';
import { ToastEvokeService } from '@costlydeveloper/ngx-awesome-popup';
@Component({
  selector: 'Kt-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  public progress: number;
  public message: string;
  @Input()pathService:string;
  @Input()id:number;
  static endPoint: string = `${environment.URL}api/Candidat/UploadCV`;
  @Output() public onUploadFinished = new EventEmitter();
  constructor(private http: HttpClient, private toastEvokeService:ToastEvokeService) {

   }
  ngOnInit() {

  }
  public uploadFile = (files:any) => {
    
    if (files.length === 0) {
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);
    this.http.post(`${UploadComponent.endPoint}/${this.id}`, formData, {reportProgress: true, observe: 'events'})
      .subscribe(event => {
        if (event.type === HttpEventType.UploadProgress)
          this.progress = Math.round(100 * event.loaded);
        else if (event.type === HttpEventType.Response) {
          this.message = 'Upload success.';
          this.toastEvokeService.success
          ('Upload success', 'Upload success').subscribe();
          this.onUploadFinished.emit(event.body);
        }
      });
  }
}
