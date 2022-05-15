import { Base, IBase } from "./Base.model";


        
export interface ITemplate extends IBase {

  technologie:string;
  them:string;
  title :string;
  note :Number;
  EvaluationId:Number;
  CommenterId:number;
}
export class Template extends Base {

      technologie:string;
      them:string;
      title :string;
      EntretienId:Number;
      NotesId :Number;
  
}





