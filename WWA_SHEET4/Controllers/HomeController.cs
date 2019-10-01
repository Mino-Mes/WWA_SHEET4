using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WWA_SHEET4.Models;

namespace WWA_SHEET4.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Sandwich newOrder)
        {
    
            double[] subPrice = new double[] { 3.99, 3.99, 5.99, 6.99, 7.99, 8.99, 9.99 };
            String subName = Enum.GetName(typeof(subName), newOrder.subName_);
            var priceOfSub = subPrice[(int)newOrder.subName_];

            double[] sizePrice = new double[] { 3, 4, 5, 6, 7 };
            String sizeName = Enum.GetName(typeof(sizeName), newOrder.sizeName_);
            var priceOfSize = sizePrice[(int)newOrder.sizeName_];

            double[] mealDeals = new double[] { 0, 3.99, 4.99 };
            String dealName = Enum.GetName(typeof(mealDealName), newOrder.mealDealName_);
            var priceOfDeal = mealDeals[(int)newOrder.mealDealName_];

            int quantity = newOrder.quantity;

            double total = Math.Round(((priceOfSub *quantity) * priceOfSize + priceOfDeal),2);
            double tax = Math.Round(total * .15,2);
            double finalTotal = tax + total;
            ViewBag.Tax = Math.Round(tax,2);
            ViewBag.Cost =Math.Round(total,2);
            ViewBag.Sub = subName;
            ViewBag.PriceSub = Math.Round(priceOfSub,2);
            ViewBag.Size = sizeName;
            ViewBag.PriceSize = Math.Round(priceOfSize,2);
            ViewBag.Deal = dealName;
            ViewBag.PriceDeal =Math.Round(priceOfDeal,2);
            ViewBag.FinalTotal =Math.Round(finalTotal,2);
            ViewBag.quantity = quantity;

            // session
            Report report = new Report(tax, total, subName, sizeName, dealName);
            Report.reportList.Add(report);

            

            return View("Receipt");
        }

        public ActionResult DailyTotal()
        {
            Report report = new Report();

            ViewBag.DailyTotal =Math.Round(report.getDailyTotal(),2);
            ViewBag.DailyTax = Math.Round(report.getTax(),2);
            return View(Report.reportList);
        }


    }
}