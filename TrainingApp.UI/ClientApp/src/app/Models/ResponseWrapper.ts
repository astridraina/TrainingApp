export enum Status
 {
   Success,
   Failure,
   SystemExcpetion
 }

 export class Validation
 {
     validationMessage: string[][]
     isValidationFailed: boolean 
 }

 export class ApiResponseWrapper<T>{
   data: T 
   status: Status
   message: string
   validation: Validation
 }