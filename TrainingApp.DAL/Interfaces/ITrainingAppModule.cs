using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.EF.TrainingAppEF;

namespace TrainingApp.DAL.Interfaces
{
  public  interface ITrainingAppModule
    {
        int Save(TrainingDetails request);
    }
}
