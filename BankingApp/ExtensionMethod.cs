using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp;

namespace MyExtension
{
    public static class ExtensionMethod
    {
        public static double getPercentageChange()
        {
            double percentChange = (Account.startingBalance / Account.currentBalance) * 100;

            return percentChange;
        }

        public static string toNAMoneyFormat(this double n, bool isRound)
        {
            string s;
            CultureInfo myCIintl = new CultureInfo("en-US", false);
            if (isRound)
               s =  Math.Abs(Math.Round((Decimal)n, 2)).ToString("C", myCIintl);
            else
                s = Math.Abs(n).ToString("C", myCIintl);
            return s;
        }
    }
}
