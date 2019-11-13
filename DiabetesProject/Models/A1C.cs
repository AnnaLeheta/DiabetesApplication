using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DiabetesProject.Models
{
    public class A1C
    {

        public int A1cID { get; set; }
        public string UserID { get; set; }

        [Display(Name = "Sugar Concentration")]
        [Range(typeof(double), "0", "25")]
        public double SugarConcentration { get; set; }

        [Display(Name = "Date of the test")]
        [Required]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime Date { get; set; }

        public virtual ApplicationUser User { get; set; }

        public A1C(int a1cID, string userID, double sugarConcentration, DateTime date)
        {
            A1cID = a1cID;
            UserID = userID;
            SugarConcentration = sugarConcentration;
            Date = date;
        }
        public A1C()
        {

        }
    }


}