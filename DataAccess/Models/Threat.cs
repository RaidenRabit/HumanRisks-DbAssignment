using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess
{
    public class Threat
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Title { get; set; }

        public int Level { get; set; }

        [ForeignKey("RiskAssessmentId")]
        public virtual RiskAssessment RiskAssessment { get; set; }
        public int? RiskAssessmentId { get; set; }
        
        public override string ToString()
        {
            try
            {
                return "\tId: " + this.Id + "\n" +
                       "\tTitle: " + this.Title + "\n" +
                       "\tLevel: " + this.Level + "\n" +
                       "\tRiskAssessmentId: " + this.RiskAssessmentId + "\n";
            }
            catch (Exception e)
            {
                return "Threat Id:" + this.Id + "\n\t" + e.Message;
            }
        }
    }

}
