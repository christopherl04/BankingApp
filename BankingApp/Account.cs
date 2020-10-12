using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp
{
    Abstract class Account : IAccount
    {
        public double startingBalance { get; set; }

        public double currentBalance { get; set; }

        private double totalOfDeposits;
        private int numberOfDeposits;

        private double totalOfWithdrawls;
        private int numberOfWithdrawls;

        private double annualInterestRate;

        private double monthlyServiceCharge;

        private enum activity
        {
            active,
            inactive
        }
        
        public Account()
        {
            this.currentBalance = currentBalance;
            this.annualInterestRate = annualInterestRate;
        }

        public void MakeDeposit()
        {
            Console.WriteLine("How much money would you like to deposit?");
            double depositAmount = Double.Parse(Console.ReadLine());
            currentBalance += depositAmount;

            numberOfDeposits++;
        }
        public void MakeWithdraw()
        {
            Console.WriteLine("How much money would you like to withdraw?");
            double withdrawAmount = Double.Parse(Console.ReadLine());
            currentBalance -= withdrawAmount;

            numberOfWithdrawls++;
        }
        public void CalculateInterest()
        {
            double monthlyInterestRate = (annualInterestRate / 12);
            double monthlyInterest = currentBalance * monthlyInterestRate;
            currentBalance += monthlyInterest;
        }
        public void CloseAndReport()
        {
            double previousBalance = currentBalance;
            double newBalance = currentBalance - monthlyServiceCharge;
            
            numberOfWithdrawls = 0;
            numberOfDeposits = 0;
            monthlyServiceCharge = 0;

            Console.WriteLine("Your previous balance was = {0} \n Your new balance is = {1}", previousBalance, newBalance);
            
        }

    }
}
