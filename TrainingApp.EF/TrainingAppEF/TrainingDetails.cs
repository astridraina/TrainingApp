using System;
using System.Collections.Generic;

namespace TrainingApp.EF.TrainingAppEF
{
    public partial class TrainingDetails
    {
        public int Id { get; set; }
        public string TrainingName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateOn { get; set; }
    }
}
