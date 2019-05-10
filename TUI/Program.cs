using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess;
using DataAccess.Accesors;

namespace TUI
{
    class Program
    {
        private static ThreatDA threatDa = new ThreatDA();
        private static RiskAssessmentDA riskAssessmentDa = new RiskAssessmentDA();
        private static Threat threat1 = new Threat {Title = "Radiations", Level = 2};
        private static Threat threat2 = new Threat {Title = "Abductions", Level = 2};
        private static RiskAssessment assessment2 = new RiskAssessment {Title = "Gravitational field imbalance", Latitude = 57.006413,
            Longitude = 9.882193};

        static void Main(string[] args)
        {

            AlertPrinting("Please make sure that you Updated the database, using the nuget console :D\n\n\n");
            FirstStep(); //insert 1 risk; print it; update it's title, latitude and longitude; print it
            LastStep(); //add threat to risk; remove threat from risk
        }

        private static void FirstStep()
        {
            //show empty db
            Console.WriteLine("Risk count: " + riskAssessmentDa.Read().Count + "\n" + "Threat count: " + threatDa.Read().Count);
            
            AlertPrinting("Inserting new Risk");

            //insert 1 risk with no threats attached
            riskAssessmentDa.Insert(assessment2);

            //print risk
            Console.WriteLine(riskAssessmentDa.Read(assessment2.id).FirstOrDefault().ToString());

            
            AlertPrinting("Updating Risk...");

            //update risk
            assessment2.Title = "Alien Invasion";
            assessment2.Latitude = 57.054624;
            assessment2.Longitude = 9.911611;
            riskAssessmentDa.Update(assessment2);

            //print risk
            Console.WriteLine(riskAssessmentDa.Read(assessment2.id).FirstOrDefault().ToString());
        }

        private static void LastStep()
        {
            AlertPrinting("New Threat detected...");

            //adding threat
            assessment2.Threats = new List<Threat>{threat1, threat2};
            riskAssessmentDa.Update(assessment2);

            //print risk
            RiskAssessment a = riskAssessmentDa.Read(assessment2.id).FirstOrDefault();
            Console.WriteLine(a.ToString());
            
            AlertPrinting("Threat neutralized...");

            //remove threat
            threatDa.Delete(threat1.Id);

            //print risk
            Console.WriteLine(riskAssessmentDa.Read(assessment2.id).FirstOrDefault().ToString());

        }

        private static void AlertPrinting(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n" + text + "\n");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
