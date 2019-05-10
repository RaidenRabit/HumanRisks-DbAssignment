using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class RiskAssessment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string Title { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<Threat> Threats { get; set; }

        public override string ToString()
        {
            string threats = "";
            if(this.Threats != null)
                foreach (var t in this.Threats)
                {
                    threats += t.ToString();
                }

            return "Risk Id: " + this.id + "\n" +
                   "Title: " + this.Title + "\n" +
                   "Latitude: " + this.Latitude + "\n" +
                   "Longitude: " + this.Longitude + "\n" + threats;
        }
    }
}
