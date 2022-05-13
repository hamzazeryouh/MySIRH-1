import { Base, IBase } from "./Base.model";


        
export interface INotes extends IBase {

  Commente:string;
  Note:string;
  
}
export class Notes extends Base {
  Commente:string;
  Note:string;
  TemplateId:number;
}





