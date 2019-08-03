using System;
using System.Collections.Generic;
using TrainingApp.BAL.Interface;
using TrainingApp.EF.TrainingAppEF;
using TrainingApp.Model.Models;
using TrainingApp.DAL.Interfaces;
using Utilities.Common;
using AutoMapper;

namespace TrainingApp.BAL.Services
{
    public class TrainingAppService : ITrainingAppService
    {
        private ITrainingAppModule _TrainingAppModule;
        private readonly IMapper _mapper;

        public TrainingAppService(ITrainingAppModule _TrainingAppModule,
            IMapper _mapper)
        {
            this._TrainingAppModule = _TrainingAppModule;
            this._mapper = _mapper;
        }

        public ApiResponseWrapper<TrainingResponse> SaveTrainingData(TrainingDetailsRequest request)
        {
            ApiResponseWrapper<TrainingResponse> response = new ApiResponseWrapper<TrainingResponse>();
            Validation validation = ValidateData(request);
            if (validation.IsValidationFailed)
            {
                response.SetFailure(new TrainingResponse(), validation);
            }
            else
            {
                TrainingDetails newTrainingDetails = _mapper.Map<TrainingDetailsRequest, TrainingDetails>(request);
                int TrainingId = _TrainingAppModule.Save(newTrainingDetails);
                if (TrainingId > 0)
                {
                    TrainingResponse responseData = new TrainingResponse()
                    {
                        TrainingId = TrainingId,
                        TrainingDays = DateDifference(request)
                    };

                    response.SetSuccess(responseData);
                }
                else
                {
                    response.SetException(new TrainingResponse());
                }

            }
            return response;
        }

        private Validation ValidateData(TrainingDetailsRequest request)
        {
            Validation objValidation = new Validation()
            {
                ValidationMessage = new List<string>()
            };
            if (string.IsNullOrEmpty(request.TrainingName))
            {
                objValidation.IsValidationFailed = true;
                objValidation.ValidationMessage.Add(CommonConstants.RequiredTrainingNameMessage);
            }
            if (request.StartDate == null || request.StartDate == DateTime.MinValue)
            {
                objValidation.IsValidationFailed = true;
                objValidation.ValidationMessage.Add(CommonConstants.InValidStartDateMessage);
            }
            if (request.EndDate == null || request.EndDate == DateTime.MinValue)
            {
                objValidation.IsValidationFailed = true;
                objValidation.ValidationMessage.Add(CommonConstants.InValidEndDateMessage);
            }
            if (request.EndDate < request.StartDate)
            {
                objValidation.IsValidationFailed = true;
                objValidation.ValidationMessage.Add(CommonConstants.InvalidDateRangeMessage);
            }
            return objValidation;
        }

        private int DateDifference(TrainingDetailsRequest request)
        {
            return Convert.ToInt32((request.EndDate.Value - request.StartDate.Value).TotalDays) + 1;
        }
    }
}
