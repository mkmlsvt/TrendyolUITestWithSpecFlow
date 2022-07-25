using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolUITestSpecFlow.Constants
{
    public static class Constant
    {
        public const string SearchBoxClassName = "search-box";
        public const string GoToProductPageA = "//*[@id='search-app']/div/div[1]/div[2]/div[5]/div/div[2]/div[1]/a";
        public const string AddToBasketButton = "add-to-basket";
        public const string PopUpCloseRemoveBasket = "//*[@id='pb-container']/div/div[3]/div[3]/div[3]/button";
        public const string RemoveToBasketButton = "//*[@id='pb-container']/div/div[3]/div[3]/div/div[3]/div/button[2]";
        public const string WarningToEmptyBasket = "//*[@id='pb-container']/div/div[1]/div[1]/span";
        public const string VerifyAddToBasketBasketCount = "//*[@id='account-navigation-container']/div/div[2]/a/div[2]";


    }
}
