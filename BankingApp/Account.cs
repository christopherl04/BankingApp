﻿using System;

namespace BankingApp
{

    abstract class Account : IAccount
    {
        public double startingBalance { get; set; }

        public double currentBalance { get; set; }

        private double totalOfDeposits;
        private int numberOfDeposits;

        private double totalOfWithdrawls;
        private int numberOfWithdrawls;

        private double annualInterestRate;

        private double monthlyServiceCharge;

        public enum activity
        {
            active = 0,
            inactive = 1
        };


        //public static bool ToBoolean(this activity value)
        //{
        //// which options should be treated as "true" ones
        //if ((activity == 0)
        //    return value == activity.inactive;
        //else
        //    return value == activity.active;
        //}


        public Account(double currentBalance, double annualInterestRate)
        {
            this.currentBalance = currentBalance;
            this.annualInterestRate = annualInterestRate;
        }

        public virtual void MakeDeposit(double depositAmount)
        {
            Console.WriteLine("How much money would you like to deposit?");
            depositAmount = Double.Parse(Console.ReadLine());
            currentBalance += depositAmount;

            numberOfDeposits++;
        }
        public virtual void MakeWithdrawl(double withdrawAmount)
        {
            Console.WriteLine("How much money would you like to withdraw?");
            withdrawAmount = Double.Parse(Console.ReadLine());
            currentBalance -= withdrawAmount;

            numberOfWithdrawls++;
        }
        public void CalculateInterest()
        {
            double monthlyInterestRate = (annualInterestRate / 12);
            double monthlyInterest = currentBalance * monthlyInterestRate;
            double totalMonthlyBalance = currentBalance += monthlyInterest;
            Console.WriteLine("Monthly interest rate = {0:C} \n Monthly interest amount = {1:C}\n Total monthly balance = {2:C}",
                                monthlyInterestRate, monthlyInterest, totalMonthlyBalance);

        }
        public virtual string CloseAndReport()
        {
            CalculateInterest();

            double previousBalance = currentBalance;
            double newBalance = currentBalance - monthlyServiceCharge;

            double percentChange = (startingBalance / newBalance) * 100;

            numberOfWithdrawls = 0;
            numberOfDeposits = 0;
            monthlyServiceCharge = 0;

            string report = string.Format("Your previous balance was = {0}" +
                "\n Your new balance is = {1}" +
                "\n The percentage of change from your starting and current balance is: {2}%",
                previousBalance, newBalance, percentChange);

            return report;

        }
        class SavingsAccount : Account
        {
            public SavingsAccount(double currentBalance, double annualInterestRate) : base(currentBalance, annualInterestRate)
            {

            }

            public override void MakeWithdrawl(double amount)
            {
                var isActive = activity.active;
                
            }
        }

        class ChequingAccount : Account
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
