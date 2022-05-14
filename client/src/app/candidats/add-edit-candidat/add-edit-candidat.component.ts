import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Location } from '@angular/common';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Appsettings } from 'src/app/App-settings/app-settings';
import { CandidatService } from 'src/app/services/candidat.service';
import { MDM } from 'src/app/Models/MDM';
import { PosteService } from 'src/app/services/poste.service';
import { PosteNiveauService } from 'src/app/services/poste-niveau.service';
import { Candidat, ICandidat } from 'src/app/Models/Candidat.model';
import { ActivatedRoute, Route, Router } from '@angular/router';
import Swal from 'sweetalert2';
import { environment } from 'src/environments/environment';
import { TemplateService } from 'src/app/services/template.service';

import {  Template } from 'src/app/Models/Template';
import { Entretien } from 'src/app/Models/Entretien';
import { EntretienService } from 'src/app/services/entretien.service';
import { Notes } from 'src/app/Models/notes';
import { notesService } from 'src/app/services/notes.service';
import { ToastEvokeService } from '@costlydeveloper/ngx-awesome-popup';



@Component({
  selector: 'app-add-edit-candidat',
  templateUrl: './add-edit-candidat.component.html',
  styleUrls: ['./add-edit-candidat.component.css'],
})
export class AddEditCandidatComponent implements OnInit {
  modal: Candidat = new Candidat();

  Civilite?: string | null;
  Nom: string | null;
  Prenom!: string | null;
  Poste!: any;
  Niveau!: any;
  form!: FormGroup;
  formNote: FormGroup;
  mode = false;
  submitted = false;
  postes!: any[];
  posteNiveau!: any[];
  id: Number;
  iditem: number;
  ImageUrl = '';
  pdfSrc = '';
  Ev: Entretien = new Entretien();
  ListTemplate: any[];
  EvMode = false;
  ListEntretien: any[];
  CandidatId: 0;
  //begin from  Entretien
  EntretienEdit:Number;
  EntretienModal: Entretien = new Entretien();
  NoteModal: Notes = new Notes();
  Evaluateur: '';
  DateEntretienn: '';
  EntretienData: any[];
  // end Entretien  
  // begin part Notes
  Notes:any;
  NoterId: 0;
  //end part notes 
  //begin Template model
  TemplateMode = false;
  Templateid: Number;
  TemplateId: 0;
  templatemodal: Template = new Template();
  //end template model
  endPoint: string = `${environment.URL}api/Candidat`;
  rating3: number;
  constructor(
    private location: Location,
    private fb: FormBuilder,
    private service: CandidatService,
    private PosteService: PosteService,
    private EntretienService: EntretienService,
    private TemplateService: TemplateService,
    private NotesService: notesService,
    private PosteNiveauService: PosteNiveauService,
    private route: ActivatedRoute,
    private Router: Router,
    private toastEvokeService: ToastEvokeService
  ) {


    this.rating3 = 0;
    this.formNote = this.fb.group({
      rating: ['', Validators.required],
    })
  }
  get error() {
    return this.form.controls;


    
  }

  ngOnInit(): void {
    this.RefrechData();
    this.initForm();

    // Get List PosteNiveau
    this.PosteNiveauService.GetResult().subscribe((result) => {
      this.posteNiveau = Object.values(result);
    });
    // Get List Poste
    this.PosteService.GetResult().subscribe((result) => {
      this.postes = Object.values(result);
    });
    this.id = Number(this.route.snapshot.paramMap.get('id'));
    this.GetListEntretien(Number(this.id));
    this.iditem = Number(this.id);
    if (this.id !== 0) {
      this.mode = true;
      this.RefrechData();
    }
  }

  RefrechData() {
    if(this.mode==true){
      this.service.Get(Number(this.id)).subscribe((data) => {
        this.modal = data;
        this.ImageUrl = String(this.modal.imageUrl);
        this.setCandidatInForm(this.modal);
        this.Nom = this.modal.nom;
        this.Prenom = this.modal.prenom;
        this.Civilite = this.modal?.civilite;
        this.PosteService.Get(this.modal.posteId).subscribe((data) => {
          let P = Object.values(data);
          this.Poste = P[0];
        });
        this.PosteNiveauService.Get(this.modal.posteNiveauId).subscribe(
          (data) => {
            let N = Object.values(data);
            this.Niveau = N[0];
          }
        );
        this.GetImage(this.modal?.imageUrl);
      });
    }
    
  }


  back(): void {
   // this.location.back();
   this.EntretienModal.id=0;
   this.EntretienModal.Evaluateur
  }

  GetImage(image: any) {
    return this.endPoint + '/GetFile/' + `${image}`;
  }
  setCandidatInForm(data: ICandidat) {
    this.form.setValue({
      nom: data.nom,
      prenom: data.prenom,
      email: data.email,
      telephone: data.telephone,
      civilite: data.civilite,
      datePremiereExperience: data.datePremiereExperience,
      dateNaissance: data.dateNaissance,
      salaireActuel: data.salaireActuel,
      propositionSalariale: data.propositionSalariale,
      residenceActuelle: data.residenceActuelle,
      emploiEncore: data.emploiEncore,
      posteId: data.posteId ?? data.posteId[1],
      posteNiveauId: data.posteNiveauId ?? data.posteNiveauId[1],
      commentaire: data.commentaire,
    });
  }

  initForm() {
    this.form = this.fb.group({
      nom: [null, [Validators.required]],
      prenom: [null, [Validators.required]],
      email: [null, [Validators.pattern(Appsettings.regexEmail)]],
      telephone: [null, [Validators.pattern(Appsettings.regexPhone)]],
      civilite: [null, [Validators.required]],
      datePremiereExperience: [null, [Validators.required]],
      dateNaissance: [null, [Validators.required]],
      salaireActuel: [null],
      propositionSalariale: [null],
      residenceActuelle: [null],
      emploiEncore: [null],
      posteId: [null, [Validators.required]],
      posteNiveauId: [null, [Validators.required]],
      commentaire: [null],
    });
  }

  // Process checkout data here

  save() {
    if (this.form.invalid) {
      return this.form.markAllAsTouched();
    }
    console.log(this.mode);
    if (this.mode == false) {
      this.modal = this.form.value;
      this.service.Add(this.modal).subscribe();
      Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Votre candidature a été enregistrée',
        showConfirmButton: false,
        timer: 1500,
      });
      this.form.reset();
      this.Router.navigate([`/candidats`]);
    } else {
      this.modal = this.form.value;
      this.modal.id = Number(this.route.snapshot.paramMap.get('id'));
      console.log(this.modal);

      this.service.Update(String(this.id), this.modal).subscribe((data) => {
        Swal.fire({
          position: 'top-end',
          icon: 'success',
          title: 'Votre candidature a été mise à jour',
          showConfirmButton: false,
          timer: 1500,
        }).catch((error) => {
          Swal.fire({
            position: 'top-end',
            icon: 'success',
            title: 'Votre candidature a été mise à jour',
            showConfirmButton: false,
            timer: 1500,
          });
        });
      });

      this.RefrechData();
    }
  }
 

  GetListEntretien(id: number) {
    this.EntretienService.GetEntretienByCandidat(id).subscribe((data) => {
      if (data != null) {
        this.EvMode = true;
      }
      this.ListEntretien=data;
      console.log(this.ListEntretien);
      
     // this.EntretienModal.id = data?.Entretien.id;
     /* this.EntretienModal.DateEntretien = data?.Entretien?.dateEntretienn;
      this.EntretienModal.Evaluateur = data?.Entretien?.evaluateur;
      this.EntretienModal.Note=data?.Entretien?.Note;
      this.ListTemplate = data?.template;*/
      
    });
  }

  addTemplate() {
    debugger;
    if (this.EntretienModal.id == null) {
      Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Vous devez ajouter Candidate First !',
      });
      return null;
    }
    this.templatemodal.EntretienId = this.EntretienModal.id;
    this.templatemodal.id=Number( this.Templateid);
    if (this.TemplateMode == true) {
      this.TemplateService.Update(
        this.Templateid.toString(),
        this.templatemodal
      ).subscribe((data) => {});
      this.GetListEntretien(Number(this.id));
    } else {
      this.TemplateService.Add(this.templatemodal).subscribe((data) => {
        this.ListTemplate.push(data);
      });
      this.templatemodal = new Template();
      this.GetListEntretien(Number(this.id));
    }
  }
/*
  AddNoter() {
    this.NoterService.Add(this.NoteModal).subscribe((data) => {
      this.EntretienModal.NoterId = Number(data.id);
      console.log(data.id);
    });
  }
  EditNoter(){
    this.NoterService.Update(this.NoteModal.id.toString(), this.NoteModal).subscribe((data) => {
      this.EntretienModal.NoterId = Number(data.id);
      console.log(data.id);
    });
  }
*/
editEntretien(id:Number){
this.EntretienModal.id=Number(id);
}

deleteEntretien(id:Number){

  this.EntretienService.Delete(Number(id)).subscribe(data=>{
    Swal.fire({
      position: 'top-end',
      icon: 'success',
      title: 'Votre candidature a été mise à jour',
      showConfirmButton: false,
      timer: 1500,
    });
  })

}
  AddEntretien() {
    if ((this.EvMode == false)) {
      this.EntretienModal.CandidatId = Number(this.id);
      this.EntretienService.Add(this.EntretienModal).subscribe((data) => {
        this.templatemodal.EntretienId = data.id;
        this.EntretienModal = data;
        this.templatemodal = new Template();
        this.EvMode = true;
      });
    } else {
      this.EntretienModal.CandidatId = Number(this.id);
      this.EntretienService.Update(
        this.EntretienModal.id.toString(),
        this.EntretienModal
      ).subscribe((data) => {
        this.templatemodal.EntretienId = data.id;
        this.EntretienModal = data;
        this.addTemplate();
        this.EvMode = true;
      });
    }
  }

  EditTemplate(id: Number) {
    this.TemplateMode = true;
    this.TemplateService.Get(Number(id)).subscribe((data) => {
     
      this.templatemodal.title = data.title;
      this.templatemodal.technologie = data.technologie;
      this.templatemodal.them = data.them;
      this.Templateid = data.id;
    });
  }

  deleteTemplate(id: Number) {
    this.TemplateService.Delete(Number(id)).subscribe((data) => {
      // this.ListTemplate=[];
    });
    this.GetListEntretien(Number(this.id));
  
  }

  AjouteNotes(TemplateId:Number){
    this.NoteModal.TemplateId=Number(TemplateId);
    this.NotesService.Add(this.NoteModal).subscribe(data=>{
    });
    this.NoteModal=new Notes();
  }

  editNotes(NoteId:Number){
    this.NoteModal.Note
    //this.NoteModal.TemplateId=Number(TemplateId);
    this.NotesService.Add(this.NoteModal).subscribe(data=>{
    });
    this.NoteModal=new Notes();
  }

  setEntretienid(id:Number){
   console.log("****************"+id);
   debugger;
   this.EntretienModal.id=Number(id);
  }
}
