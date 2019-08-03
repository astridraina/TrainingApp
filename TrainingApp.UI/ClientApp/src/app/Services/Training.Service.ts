import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { AppConfig } from '../Services/app.config';
import {TrainingDetails} from '../Models/TrainingDetails';
import {TrainingDetailsResponse} from '../Models/TrainingDetailsResponse';
import {Status, Validation, ApiResponseWrapper} from '../Models/ResponseWrapper';
import {httpOptions} from '../Constants/Contants'



@Injectable({
  providedIn: 'root',
})

export class TrainingAppService {
  
constructor(private http: HttpClient) { }
  private baseurl:string =  AppConfig.settings && AppConfig.settings.apiServer.BaseUrl ?
                  AppConfig.settings.apiServer.BaseUrl : '';
                  
 private saveTrainingUrl = this.baseurl + "Training";
 public traingDetailsResponse: ApiResponseWrapper<TrainingDetailsResponse>;


  SaveTrainingDetails (trainingDetails: TrainingDetails): Observable<ApiResponseWrapper<TrainingDetailsResponse>> {
    debugger;
    return this.http.post<ApiResponseWrapper<TrainingDetailsResponse>>(this.saveTrainingUrl, trainingDetails, httpOptions).pipe(
      map((data: ApiResponseWrapper<TrainingDetailsResponse>) => {
        this.traingDetailsResponse = data;
        return this.traingDetailsResponse;
    }
    ));
}

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
   
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  }
