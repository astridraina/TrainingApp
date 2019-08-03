using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingApp.BAL.Interface;
using TrainingApp.EF.TrainingAppEF;
using TrainingApp.Model.Models;

namespace TrainingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class TrainingController : ControllerBase
    {
        private ITrainingAppService _TrainingAppService;

        public TrainingController(ITrainingAppService _TrainingAppService)
        {
            this._TrainingAppService = _TrainingAppService;
        }


        [HttpPost]
        public ApiResponseWrapper<TrainingResponse> Post(TrainingDetailsRequest request)
        {
            return _TrainingAppService.SaveTrainingData(request);
        }
    }
}