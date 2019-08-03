using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.EF.TrainingAppEF;
using TrainingApp.Model.Models;

namespace TrainingApp.BAL.Interface
{
    public interface ITrainingAppService
    {
        ApiResponseWrapper<TrainingResponse> SaveTrainingData(TrainingDetailsRequest request);
    }
}
