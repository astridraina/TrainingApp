using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingApp.Model.Models
{
    public class TrainingDetailsRequest
    {
        public int Id { get; set; }
        public string TrainingName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
