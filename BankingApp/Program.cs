using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyExtension;

namespace BankingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            CustomExceptions ce = new CustomExceptions("You have not entered a proper number for a money amount",
                                                        "Invalid input error", DateTime.Now);
            Console.Clear();
            string menuInput = " ";
            string input = " ";
            Console.WriteLine("Bank Menu\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("A: Savings\n" +
                              "B: Checking\n" +
                              "C: GlobalSavings\n" +
                              "Q: Exit");
            Console.ResetColor();

            do
            {
                try
                {
                    Console.Write(">> ");
                    menuInput = Console.ReadLine();
                }

                catch (CustomExceptions e)
                {
                    Console.WriteLine(e.Message);
                    Console.ReadLine();
                }
            }
            while (!(menuInput.ToLower() == "a" || menuInput.ToLower() == "b" || menuInput.ToLower() == "c" || menuInput.ToLower() == "q"));



                do
                {
                    switch (menuInput.ToLower())
                    {
                        case "a":
                            Console.WriteLine("Savings Menu\n");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("A: Deposit\n" +
                                              "B: Withdrawal\n" +
                                              "C: Close + Report\n" +
                                              "R: Return to Bank Menu");
                            Console.ResetColor();
                            Account.SavingsAccount savingsAccount = new Account.SavingsAccount(5, 12);
                            do
                            {
                            try
                            {
                                Console.Write(">> ");
                                input = Console.ReadLine();
                            }
                            catch(CustomExceptions e)
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadLine();

                            }
                            } while (!(input.ToLower() == "a" || input.ToLower() == "b" || input.ToLower() == "c" || input.ToLower() == "r"));
                            
                            switch (input.ToLower())
                            {

                                case "a":
                                    Console.WriteLine("How much money would you like to deposit?");
                                    double depositAmount = Double.Parse(Console.ReadLine());
                                    savingsAccount.MakeDeposit(depositAmount);
                                    Console.ReadLine();
                                    return true;
                            case "b":
                                    Console.WriteLine("How much money would you like to withdraw?");
                                    double withdrawAmount = Double.Parse(Console.ReadLine());
                                    savingsAccount.MakeWithdrawl(withdrawAmount);
                                    return true;
                                case "c":
                                    savingsAccount.CloseAndReport();
                                    Console.WriteLine("Press Enter to return to Main Menu");
                                    Console.ReadLine();
                                    return true;
                                case "r":
                                    return true;
                                default:
                                    return true;
                                    throw ce;
                                    
                            }
                        case "b":
                            Account.ChequingAccount chequingAccount = new Account.ChequingAccount(5, 12);
                            Console.WriteLine("Checking Menu\n");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("A: Deposit\n" +
                                              "B: Withdrawal\n" +
                                              "C: Close + Report\n" +
                                              "R: Return to Bank Menu");
                            Console.ResetColor();
                            do
                            {
                            try
                            {
                                Console.Write(">> ");
                                input = Console.ReadLine();
                            }
                            catch(CustomExceptions e)
                            {
                                Console.WriteLine(e.Message);
                                Console.ReadLine();
                            }   
                            } while (!(input.ToLower() == "a" || input.ToLower() == "b" || input.ToLower() == "c" || input.ToLower() == "r"));
                            switch (input.ToLower())
                            {
                                case "a":
                                    Console.WriteLine("How much money would you like to deposit?");
                                    double depositAmount = Double.Parse(Console.ReadLine());
                                    chequingAccount.MakeDeposit(depositAmount);
                                    Console.ReadLine();
                                    return true;
                                case "b":
                                    Console.WriteLine("How much money would you like to withdraw?");
                                    double withdrawAmount = Double.Parse(Console.ReadLine());
                                    chequingAccount.MakeWithdrawl(withdrawAmount);
                                    return true;
                                case "c":
                                    chequingAccount.CloseAndReport();
                                    Console.WriteLine("Press Enter to return to Main Menu");
                                    Console.ReadLine();
                                    return true;
                                case "r":
                                    return true;
                                default:
                                    return true;
                                    throw ce;
                            }
                        case "c":
                            Account.SavingsAccount.GlobalSavingsAccount globalSavingsAccount = new Account.SavingsAccount.GlobalSavingsAccount(5, 12);
                            do
                            {
                            try
                            {
                                Console.WriteLine("Global Savings Menu\n");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("A: Deposit\n" +
                                                   "B: Withdrawal\n" +
                                                   "C: Close + Report\n" +
                                                   "D: Report Balance in USD\n" +
                                                   "R: Return to Bank Menu");
                                Console.ResetColor();
                                Console.Write(">> ");
                                input = Console.ReadLine();
                            }
                            catch(CustomExceptions e)
                            {
                                Console.WriteLine(e.Message);

                            }
                            } while (!(input.ToLower() == "a" || input.ToLower() == "b" || input.ToLower() == "c" || input.ToLower() == "d" || input.ToLower() == "r"));

                            switch (input.ToLower())
                            {
                                case "a":
                                    Console.WriteLine("How much money would you like to deposit?");
                                    double depositAmount = Double.Parse(Console.ReadLine());
                                    globalSavingsAccount.MakeDeposit(depositAmount);
                                    Console.ReadLine();

                                    return true;
                                case "b":
                                    Console.WriteLine("How much money would you like to withdraw?");
                                    double withdrawAmount = Double.Parse(Console.ReadLine());
                                    globalSavingsAccount.MakeWithdrawl(withdrawAmount);
                                    return true;
                                case "c":
                                    globalSavingsAccount.CloseAndReport();
                                    Console.WriteLine("Press Enter to return to Main Menu");
                                    Console.ReadLine();
                                    return true;
                                case "d":
                                    Console.Write("Enter the conversion rate>> ");
                                    double rate = Double.Parse(Console.ReadLine());
                                    globalSavingsAccount.USValue(rate);
                                    Console.ReadLine();
                                    return true;
                                case "r":
                                    return true;
                                default:                                    
                                    return true;
                                    throw ce;
                            }
                        case "q":
                            Environment.Exit(1);
                            return false;
                    }
                } while (!(menuInput.ToLower() == "a" || menuInput.ToLower() == "b" || menuInput.ToLower() == "c" || menuInput.ToLower() == "q"));
                return true;
            }
    }
    
}

