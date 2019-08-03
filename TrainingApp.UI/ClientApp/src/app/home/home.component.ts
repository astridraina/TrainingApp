import { Component, OnInit, ChangeDetectorRef  } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';


//Imported Services
import {TrainingAppService} from '../Services/Training.Service';

//Imported Models
import {TrainingDetails} from '../Models/TrainingDetails';
import {TrainingDetailsResponse} from '../Models/TrainingDetailsResponse';
import {Status, Validation, ApiResponseWrapper} from '../Models/ResponseWrapper';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

constructor(private trainingService: TrainingAppService,
  private _ref: ChangeDetectorRef){
}
  
trainingDetails: TrainingDetails;
trainingResp: ApiResponseWrapper<TrainingDetailsResponse>;
message:string;
validationFailedMessage:string
validationFailed:boolean;

ngOnInit() {
  this.trainingDetails = new TrainingDetails();
  this.trainingResp = new ApiResponseWrapper();
  this.message= "";
  this.validationFailedMessage= "";
  this.validationFailed = false;
}


SaveTrainingDetails(): void {
 debugger;
 var _this = this;
 this.trainingService.SaveTrainingDetails(this.trainingDetails)
 .subscribe(function (data) {
      _this.trainingResp = data;
      _this.message = "";
      _this.validationFailedMessage ="";
      if(_this.trainingResp.status == Status.Success)
      {
        _this.message = "The training is successfully saved"+ '<br/>';
        _this.message = _this.message +  "Total number of training days are " + _this.trainingResp.data.trainingDays
      }
      else if(_this.trainingResp.status == Status.Failure)
      {
        _this.message = "The training is not saved due to validation errors";
        _this.trainingResp.validation.validationMessage.forEach(element => {
          _this.validationFailedMessage = _this.validationFailedMessage + element + '<br/>';
          _this._ref.markForCheck();
          console.log(_this.message);
        });
      }
      else if(_this.trainingResp.status == Status.SystemExcpetion)
      {
        _this.message = "There was a system error. Kindly try later";
      }
      
});
}
}
