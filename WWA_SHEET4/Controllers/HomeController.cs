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

            double total = priceOfSub * priceOfSize + priceOfDeal;
            double tax = total * .15;
            double finalTotal = tax + total;
            ViewBag.Tax = tax;
            ViewBag.Cost = total;
            ViewBag.Sub = subName;
            ViewBag.PriceSub = priceOfSub;
            ViewBag.Size = sizeName;
            ViewBag.PriceSize = priceOfSize;
            ViewBag.Deal = dealName;
            ViewBag.PriceDeal = priceOfDeal;
            ViewBag.FinalTotal = finalTotal;


            return View("Receipt");
        }


    }
}