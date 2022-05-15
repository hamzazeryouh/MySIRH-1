import { Base, IBase } from "./Base.model";


        
export interface IEntretien extends IBase {

      Evaluateur  :string;
      DateEntretien :Date;
      CandidatId   :number;
      CommenterId :number;
      TemplateId :number
      Note:string;
      Commente :string;
  
}
export class Entretien extends Base {
      evaluateur  :string;
      dateEntretien :Date;
      candidatId   :number;
      commente :string;
}

