using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.EF.TrainingAppEF;
using TrainingApp.Model.Models;

namespace TrainingApp.BAL.MappingProfile
{
    public class TrainingDetailsMappingProfile : Profile
    {
        public TrainingDetailsMappingProfile()
        {
            CreateMap<TrainingDetailsRequest, TrainingDetails>()
                .ReverseMap();
        }
    }
}
