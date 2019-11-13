using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace DiabetesProject.Models
{
    public class A1CViewModel
    {
        public List<A1C> A1c { get; set; }

        public Chart Chart { get; set; }

        public A1CViewModel(List<A1C> list)
        {
            A1c = list;
            Chart = GetChart();
        }

        private Chart GetChart()
        {
            ArrayList xValues = new ArrayList(); 
            ArrayList yValues = new ArrayList();
            if (A1c == null)
            {
                return null;
            }
            else
            {
                foreach (A1C e in A1c)
                {
                    xValues.Add(e.Date.ToShortDateString());
                    yValues.Add(e.SugarConcentration);
                }
                return new Chart(600, 400, ChartTheme.Blue)
                .AddTitle("Your A1C Chart")
                .AddSeries(
                    name: "A1C",
                    chartType: "Column",
                    xValue: xValues,
                    yValues: yValues);
            }
            
        }
    }
}