import { Component, Input, OnInit } from '@angular/core';
import { Entretien } from 'src/app/Models/Entretien';

@Component({
  selector: 'Kt-ev-candidat',
  templateUrl: './evaluation-candidat.component.html',
  styleUrls: ['./evaluation-candidat.component.css']
})
export class EvaluationCandidatComponent implements OnInit {

constructor() { }
@Input()Entretien:any;
  ngOnInit(): void {
  }

}
