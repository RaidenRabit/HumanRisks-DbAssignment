using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Accesors
{
    public class ThreatDA
    {
        public int Insert(Threat threat)
        {
            using (var db = new RiskAssessmentDbContext())
            {
                db.Threats.Add(threat);
                db.SaveChanges();
                return threat.Id;
            }
        }

        public List<Threat> Read(int id = 0)
        {
            using (var db = new RiskAssessmentDbContext())
            {
                if (id == 0)
                    return db.Threats
                        .ToList();

                return new List<Threat> {db.Threats.FirstOrDefault(item => item.Id == id)};                
            }
        }

        public void Delete(int id)
        {
            using (var db = new RiskAssessmentDbContext())
            {
                Threat t = Read(id).FirstOrDefault();

                if (t != null)
                {
                    db.Threats.Remove(t);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("No Threat has the ID: " + id);
                }
            }
        }
    }
}
