using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWA_SHEET4.Models
{
    public class Report
    {
        public static List<Report> reportList = new List<Report>();

        public double tax { get; set; }
        public double cost { get; set; }
        public String subType { get; set; }
        public String subSize { get; set; }
        public String mealDeal { get; set; }

        public Report(double _tax, double _cost, String _subType, String _subSize, String _mealDeal)
        {
            tax = _tax;
            cost = _cost;
            subType = _subType;
            subSize = _subSize;
            mealDeal = _mealDeal;
        }
        public Report()
        { }

        public double getTax()
        {
           double taxTotal = 0;
            foreach (var x in reportList)
            {
                taxTotal += x.tax;
            }

            return taxTotal;
        }

        public double getDailyTotal()
        {
            double total = 0;
            foreach (var x in reportList)
            {
                total += (x.tax + x.cost);
            }
            return total;
        }
    }
}