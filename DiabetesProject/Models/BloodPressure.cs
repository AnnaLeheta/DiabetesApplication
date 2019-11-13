using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesProject.Models
{
    public class BloodPressure
    {
        public int BloodPressureID { get; set; }
        public string UserID { get; set; }

        [Display(Name = "Systolic Pressure")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be a positive real number")]
        [Range(0, 260, ErrorMessage = "Cannot exceed 260")]
        public string SystolicPressure { get; set; }

        [Display(Name = "Diastolic Pressure")]
        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be a positive real number")]
        [Range(0, 160, ErrorMessage = "Cannot exceed 160")]
        public string DiastolicPressure { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Must be a positive real number")]
        [Range(0, 240, ErrorMessage = "Cannot exceed 240")]
        public Nullable<int> Pulse { get; set; }

        [EnumDataType(typeof(Hand))]
        public Hand? MeasuredArm { get; set; }

        [Display(Name = "Date of the test")]
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime Date { get; set; }

        public virtual ApplicationUser User { get; set; }

        public BloodPressure(int bloodPressureID,string userID, string systolicPressure, string diastolicPressure, int? pulse, Hand? measuredArm, DateTime date)
        {
                       
            BloodPressureID = bloodPressureID;
            UserID = userID;
            SystolicPressure = systolicPressure;
            DiastolicPressure = diastolicPressure;
            Pulse = pulse;
            MeasuredArm = measuredArm;
            Date = date;
        }
        public BloodPressure()
        {

        }
    }

    public enum Hand
    {
        Right, Left
    }
}