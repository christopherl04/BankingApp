using MyExtension;
using System;

namespace BankingApp
{

     abstract class Account : IAccount
    {
        public static double startingBalance;
        public static double currentBalance;
        private double totalDeposits;
        private int numberDeposits;
        private double totalWithdrawls;
        private int numberWithdrawls;
        public double annualInterestRate;
        private double monthServiceCharge;
        private enum Acticity
        {
            active,
            inactive
        };

        public double StartingBalance { get { return startingBalance;} set { startingBalance = value; } }
        public double CurrentBalance { get {return currentBalance; }}

        protected Account(double startingBalance, double annualInterestRate)
        {
            StartingBalance = startingBalance;
            this.annualInterestRate = annualInterestRate;
        }
       

        
        public virtual void MakeDeposit(double amount)
        {
            currentBalance += amount + startingBalance;
            numberDeposits++;
        }

        public virtual void MakeWithdrawl(double amount)
        {
            currentBalance -= amount + startingBalance;
            numberWithdrawls++;
        }
        public void CalculateInterest()
        {
            double monthlyInterestRate = annualInterestRate / 12;
            double monthlyInterest = CurrentBalance * monthlyInterestRate;
            currentBalance += monthlyInterest;
            Console.WriteLine("Annual Interest Rate: {0}%\n" +
                              "Monthly Interest Rate: {1}%\n" +
                              "Monthly Interest: {2:C}", annualInterestRate, monthlyInterestRate, monthlyInterest.toNAMoneyFormat(true));
        }

        public virtual string CloseAndReport()
        {
            currentBalance -= monthServiceCharge;
            CalculateInterest();
            numberDeposits = 0;
            numberWithdrawls = 0;
            monthServiceCharge = 0;
            double percentChange = MyExtension.ExtensionMethod.getPercentageChange();
            string report = string.Format("Previous Balance: {0:C}\n" +
                                          "New Balance: {1:C}\n" +
                                          "Percentage change from the starting the current balances: {2}%"
                              ,StartingBalance.toNAMoneyFormat(true), CurrentBalance.toNAMoneyFormat(true), percentChange);
            Console.WriteLine(report);
            return report;
        }
            
        

        public class SavingsAccount : Account
        {
            public double StartingBalance { get { return startingBalance; } }
            public double CurrentBalance { get { return currentBalance; } }
            Acticity status;
            public SavingsAccount(double startingBalance, double annualInterestRate) : base(startingBalance, annualInterestRate)
            {
                if (currentBalance < 25)
                    status = Acticity.inactive;
                else
                    status = Acticity.active;
            }

            public override void MakeWithdrawl(double amount)
            {
                if (status == Acticity.active)
                    base.MakeWithdrawl(amount);
                else
                    Console.WriteLine("Your account status is currently inactive.\nTo activavte your account, your balance must be above $25.00.");
            }

            public override void MakeDeposit(double amount)
            {
                if (status == Acticity.inactive && (amount + currentBalance) > 25)
                    base.MakeDeposit(amount);
                else if (status == Acticity.inactive)
                    Console.WriteLine("Your account status is currently inactive.\nTo activavte your account, your balance must be above $25.00.");
                else
                {
                    base.MakeDeposit(amount);
                }
            }

            public override string CloseAndReport()
            {
                if (numberWithdrawls > 4)
                {
                    int serviceCharge = numberWithdrawls - 4;
                    monthServiceCharge += serviceCharge;
                }
                return base.CloseAndReport();
            }

            public class GlobalSavingsAccount : SavingsAccount, IExchangeable
            {
                public GlobalSavingsAccount(double startingBalance, double annualInterestRate) : base(startingBalance, annualInterestRate)
                {
                }

                public double USValue(double rate)
                {
                    double conversion = rate * currentBalance;
                    Console.WriteLine("The conversion equals to {0:C}.",conversion.toNAMoneyFormat(true));
                    return conversion;
                }
            }
        }

        public class ChequingAccount : Account
        {
            public ChequingAccount(double startingBalance, double annualInterestRate) : base(startingBalance, annualInterestRate)
            {
            }

            public override void MakeWithdrawl(double amount)
            {
                if((currentBalance - amount) < 0)
                {
                    monthServiceCharge = 15;
                    currentBalance -= monthServiceCharge;
                    Console.WriteLine("Withdrawl will not be made due to insufficient funds.");
                }else
                    base.MakeWithdrawl(amount);
            }

            public override void MakeDeposit(double amount)
            {
                base.MakeDeposit(amount);
            }
        }

    }
}
