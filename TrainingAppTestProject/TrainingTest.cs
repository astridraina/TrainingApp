using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TrainingApp.BAL.Interface;
using TrainingApp.BAL.MappingProfile;
using TrainingApp.BAL.Services;
using TrainingApp.Controllers;
using TrainingApp.DAL.Interfaces;
using TrainingApp.DAL.Module;
using TrainingApp.EF.TrainingAppEF;
using TrainingApp.Model.Models;
using Utilities.Enum;

namespace TrainingAppTestProject
{
    [TestClass]
    public class TrainingTest
    {
        ITrainingAppService _TrainingAppService;
        TrainingController _controller;
        private readonly IMapper _mapper;

        public TrainingTest()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new TrainingDetailsMappingProfile());
            });
            _mapper = mockMapper.CreateMapper();

            var mockDal = new Mock<ITrainingAppModule>();
            mockDal.Setup(d => d.Save(It.IsAny<TrainingDetails>())).Returns(1);
            _TrainingAppService = new TrainingAppService(mockDal.Object, _mapper);
            _controller = new TrainingController(_TrainingAppService);

        }


        [TestMethod]
        public void TrainingPost_PositiveTest()
        {



            TrainingDetailsRequest request = new TrainingDetailsRequest()
            {
                TrainingName = "Training 1",
                StartDate = new DateTime(2019, 06, 10),
                EndDate = new DateTime(2019, 07, 10)
            };



            ApiResponseWrapper<TrainingResponse> response = _controller.Post(request);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Data);
            Assert.AreEqual(response.Status, Status.Success);
            Assert.AreNotEqual(response.Data.TrainingId, 0);
            Assert.AreNotEqual(response.Data.TrainingDays, 0);
        }

        [TestMethod]
        public void TrainingPost_NegativeTest()
        {

            TrainingDetailsRequest request = new TrainingDetailsRequest()
            {
                TrainingName = "Training 1",
                StartDate = new DateTime(2019, 08, 10),
                EndDate = new DateTime(2019, 07, 10)
            };
            ApiResponseWrapper<TrainingResponse> response = _controller.Post(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Failure);
            Assert.AreEqual(response.validation.IsValidationFailed, true);
            Assert.AreNotEqual(response.validation.ValidationMessage.Count, 0);
        }

        [TestMethod]
        public void TrainingPost_MissingDataTest()
        {

            TrainingDetailsRequest request = new TrainingDetailsRequest()
            {
                StartDate = new DateTime(2019, 08, 10),
                EndDate = new DateTime(2019, 07, 10)
            };
            ApiResponseWrapper<TrainingResponse> response = _controller.Post(request);
            Assert.IsNotNull(response);
            Assert.AreEqual(response.Status, Status.Failure);
            Assert.AreEqual(response.validation.IsValidationFailed, true);
            Assert.AreNotEqual(response.validation.ValidationMessage.Count, 0);
        }
    }
}
