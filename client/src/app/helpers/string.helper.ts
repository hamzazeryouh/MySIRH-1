export  class stringHelper {

    static  ConvertStringToNumber(input: string) { 
    
        if (!input) return NaN;
    
        if (input.trim().length==0) { 
            return NaN;
        }
        return Number(input);
    }

}