using System;
using System.Collections.Generic;
using System.Text;
using TrainingApp.DAL.Interfaces;
using TrainingApp.EF.TrainingAppEF;

namespace TrainingApp.DAL.Module
{
    public class TrainingAppModule : ITrainingAppModule
    {
        private readonly TrainingAppDbContext _context;
        public TrainingAppModule(TrainingAppDbContext context)
        {
            _context = context;
        }
        
        public int Save(TrainingDetails request)
        {
            try
            {
                request.IsActive = true;
                request.CreatedBy = "System";
                request.CreatedOn = DateTime.Now;
                _context.Add(request);
                int val = _context.SaveChanges();
                return request.Id;
            }
            catch (Exception ex)
            {
                return -1;
            }

        }
    }
}
