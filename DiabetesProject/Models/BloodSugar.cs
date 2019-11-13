using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesProject.Models
{
    public class BloodSugar
    {
        public int BloodSugarID { get; set; }
        public string UserID { get; set; }

        [Display(Name = "Sugar Concentration")]
        [Required]
        [Range(0.0, Double.MaxValue, ErrorMessage = "Sugar concentration should be valid number")]
        public string SugarConcentration { get; set; }

        [Display(Name = "Hand measured")]
        [Required]
        [EnumDataType(typeof(Hand))]
        public string Measured { get; set; }

        [Display(Name = "Date of the test")]
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime Date { get; set; }

        public double Weight { get; set; }

        public virtual ApplicationUser User { get; set; }

        public BloodSugar(int bloodSugarID, string userID, string sugarConcentration, string measured, DateTime date, double weight)
        {
            BloodSugarID = bloodSugarID;
            UserID = userID;
            SugarConcentration = sugarConcentration;
            Measured = measured;
            Date = date;
            Weight = weight;
        }
        public BloodSugar()
        {

        }
    }
}