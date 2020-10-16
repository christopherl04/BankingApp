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
        private double annualInterestRate;
        private double monthServiceCharge;


        public static double StartingBalance { get { return startingBalance;} set { startingBalance = value; } }
        public static double CurrentBalance { get {return currentBalance; } set { currentBalance = value; } }

        protected Account(double startingBalance, double annualInterestRate)
        {
            StartingBalance = startingBalance;
            this.annualInterestRate = annualInterestRate;
        }

        private enum Acticity
        {
            active,
            inactive
        };
        public virtual void MakeDeposit(double amount)
        {
            Account.CurrentBalance += amount + startingBalance;
            Console.WriteLine("deposit works");
            Console.WriteLine(CurrentBalance);
            numberDeposits++;
        }

        public virtual void MakeWithdrawl(double amount)
        {
            Account.CurrentBalance -= amount + startingBalance;
            numberWithdrawls++;
        }
        public void CalculateInterest()
        {
            double monthlyInterestRate = annualInterestRate / 12;
            Console.WriteLine(annualInterestRate);
            double monthlyInterest = CurrentBalance * monthlyInterestRate;
            Console.WriteLine(CurrentBalance + " e");
            currentBalance += monthlyInterest;
            Console.WriteLine("Monthly Interest Rate: {0}%\n" +
                              "Monthly Interest: {1:C}",monthlyInterestRate,monthlyInterest);
        }

        public virtual string CloseAndReport()
        {
            CurrentBalance -= monthServiceCharge;
            CalculateInterest();
            numberDeposits = 0;
            numberWithdrawls = 0;
            monthServiceCharge = 0;
            double percentChange = (StartingBalance / CurrentBalance) * 100;
            string report = string.Format("Previous Balance: {0:C}\n" +
                                          "New Balance: {1:C}\n" +
                                          "Percentage change from the starting the current balances: {2}%"
                              ,StartingBalance, CurrentBalance, percentChange);
            Console.WriteLine(report);
            return report;
        }
            
        

        public class SavingsAccount : Account
        {
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
                    Console.WriteLine("The conversion equals to {0:C}.",conversion);
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
