using System;
using System.Collections.Generic;
using System.Text;
using Utilities.Enum;

namespace TrainingApp.Model.Models
{
    public class ApiResponseWrapper<T>
    {
        public T Data { get; set; }
        public Status Status { get; set; }
        public string Message { get; set; }
        public Validation validation { get; set; }

        public void SetSuccess(T Data)
        {
            this.Data = Data;
            this.Status = Status.Success;
            this.Message = "Data Saved Successfully";
        }


        public void SetFailure(T Data, Validation validation)
        {
            this.Data = Data;
            this.Status = Status.Failure;
            this.Message = "Invali Data";
            this.validation = validation;
        }


        public void SetException(T Data)
        {
            this.Data = Data;
            this.Status = Status.SystemExcpetion;
            this.Message = "System Failure";
        }
    }
}
