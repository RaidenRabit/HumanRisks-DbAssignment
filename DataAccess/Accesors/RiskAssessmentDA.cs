using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Accesors
{
    public class RiskAssessmentDA
    {
        public int Insert(RiskAssessment risk)
        {
            using (var db = new RiskAssessmentDbContext())
            {
                db.RiskAssessments.Add(risk);
                db.SaveChanges();
                return risk.id;
            }
        }

        public List<RiskAssessment> Read(int id = 0)
        {
            using (var db = new RiskAssessmentDbContext())
            {
                if(id == 0)
                return db.RiskAssessments
                    .Include(c => c.Threats)
                    .ToList();
                var a = new List<RiskAssessment> {db.RiskAssessments.Include(c=>c.Threats).FirstOrDefault(item => item.id == id)};
                return a;
            }
        }

        public void Update(RiskAssessment riskAssessment)
        {
            using (var db = new RiskAssessmentDbContext())
            {
                RiskAssessment r = Read(riskAssessment.id).FirstOrDefault();

                if (r != null)
                {
                    r.Title = riskAssessment.Title;
                    r.Latitude = riskAssessment.Latitude;
                    r.Longitude = riskAssessment.Longitude;
                    r.Threats = riskAssessment.Threats;

                    db.RiskAssessments.Update(r);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("No Risk has the ID: " + riskAssessment.id);
                }
            }
        }
    }
}
