using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WWA_SHEET4.Models
{
    public class Sandwich
    {
        public subName subName_ { get; set; }
        public sizeName sizeName_ { get; set; }
        public mealDealName mealDealName_ { get; set; }
        public int quantity { get; set; } = 1;
    }
    public enum subName
    {
        TheMichealJackson,
        ThePrince,
        TheBackStreetBoys,
        TheBeyonce
    }

    public enum sizeName
    {
        onehitwonder,
        blist,
        alist,
        superstar
    }

    public enum mealDealName
    {
        None,
        DrinksAndChips,
        DrinksandCookies
    }
}