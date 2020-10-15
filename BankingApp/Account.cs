using System;

namespace BankingApp
{

    abstract class Account : IAccount
    {
        public double startingBalance { get; set; }

        public double currentBalance { get ; set; }

        private double totalOfDeposits;
        private int numberOfDeposits;

        private double totalOfWithdrawls;
        private int numberOfWithdrawls;

        private double annualInterestRate;

        private double monthlyServiceCharge;

        public enum activity
        {
            active,
            inactive
        };

        public Account(double currentBalance, double annualInterestRate)
        {
            this.currentBalance = currentBalance;
            this.annualInterestRate = annualInterestRate;
        }

        public virtual void MakeDeposit(double depositAmount)
        {
            currentBalance += depositAmount;
            Console.WriteLine(currentBalance);
            Console.ReadKey();
            numberOfDeposits++;
        }
        public virtual void MakeWithdrawl(double withdrawAmount)
        {
            currentBalance -= withdrawAmount;

            numberOfWithdrawls++;
        }
        public void CalculateInterest()
        {
            double monthlyInterestRate = (annualInterestRate / 12);
            double monthlyInterest = currentBalance * monthlyInterestRate;
            double totalMonthlyBalance = currentBalance += monthlyInterest;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Monthly interest rate: {0:C} \nMonthly interest amount: {1:C}\nTotal monthly balance: {2:C}",
                                monthlyInterestRate, monthlyInterest, totalMonthlyBalance);
        }
        public virtual string CloseAndReport()
        {
            CalculateInterest();
            Console.WriteLine();
            numberOfWithdrawls = 0;
            numberOfDeposits = 0;
            double previousBalance = currentBalance;
            double newBalance = previousBalance - monthlyServiceCharge;

            double percentChange = (startingBalance / newBalance) * 100;

            
            string report = string.Format("Your previous balance was : {0}" +
                                           "\nYour new balance is: {1}" +
                                           "\nThe percentage of change from your starting and current balance is: {2}%",
                                            previousBalance, newBalance, percentChange);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(report);
            Console.ResetColor();
            return report;

        }
        public class SavingsAccount : Account
        {
            activity status;
            public SavingsAccount(double currentBalance, double annualInterestRate) : base(currentBalance, annualInterestRate)
            {
                if (currentBalance < 25)
                {
                    status = activity.inactive;
                }
                else
                {
                    status = activity.active;
                }
            }

            public override void MakeWithdrawl(double amount)//set enum in constructor, instantiate it as an object instead of bool and then set it. and it's -25
            {
                if (status == activity.active)
                {
                    base.MakeWithdrawl(amount);
                }
                else
                {
                    Console.WriteLine("Account is innactive due to funds being lower than $25." +
                                      "\nRaise the balance to make future withdrawls.");
                }
            }

            public override void MakeDeposit(double depositAmount)
            {

                if (status == activity.inactive && (currentBalance + depositAmount) > 25)
                {
                    base.MakeDeposit(depositAmount);
                    status = activity.active;
                    Console.WriteLine("Funds have been deposited. Account is now active!");
                }
                else
                {
                    Console.WriteLine("Funds have been deposited but the account remains" +
                                      " innactive due to funds being lower than $25." +
                                      "\nRaise the balance to re-activate the account.");
                }
            }

            public override string CloseAndReport()
            {
                if (numberOfWithdrawls > 4)
                {
                    int moreThanFour = 4 - numberOfWithdrawls;
                    int absoluteValue = Math.Abs(moreThanFour);
                    int serviceCharge = 1 * absoluteValue;
                    monthlyServiceCharge += serviceCharge;
                }
                else
                {
                    return base.CloseAndReport();
                }
                return base.CloseAndReport();
            }

            public class GlobalSavingsAccount : Account, IExchangeable
            {
                public GlobalSavingsAccount(double currentBalance, double annualInterestRate) : base(currentBalance, annualInterestRate)
                {
                }

                public double USValue(double rate)
                {
                    return rate * currentBalance;
                }
            }
        }

        public class ChequingAccount : Account
        {
            public ChequingAccount(double currentBalance, double annualInterestRate) : base(currentBalance, annualInterestRate)
            {

            }
            public override void MakeWithdrawl(double amount)
            {
                double withdrawl = currentBalance - amount;
                if (withdrawl < 0)
                {
                    Console.WriteLine("The withdrawal will not be made due to insufficient funds.");
                    monthlyServiceCharge = 15;
                    currentBalance -= monthlyServiceCharge;
                }
                else if (withdrawl > 0)
                {
                    base.MakeWithdrawl(amount);
                }
            }

            public override void MakeDeposit(double depositAmount)
            {
                base.MakeDeposit(depositAmount);
            }

            public override string CloseAndReport()
            {
                double withdrawlCharge = 0.1 * numberOfWithdrawls;
                monthlyServiceCharge = 5 + withdrawlCharge;
                return base.CloseAndReport();
            }
        }

    }
}
