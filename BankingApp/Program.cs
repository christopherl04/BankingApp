using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Console.Clear();
            string menuInput;
            string input;
           
            Console.WriteLine("Bank Menu\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("A: Savings\n" +
                              "B: Checking\n" +
                              "C: GlobalSavings\n" +
                              "Q: Exit");
            Console.ResetColor();
            Console.Write(">> ");

            menuInput = Console.ReadLine();
            do
            {
                switch (menuInput.ToLower())
                {
                    case "a":
                        Console.WriteLine("Savings Menu\n");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("A: Deposit\n" +
                                          "B: Withdrawal\n" +
                                          "C: Close + Report\n" +
                                          "R: Return to Bank Menu");
                        Console.ResetColor();
                        Account.SavingsAccount savingsAccount = new Account.SavingsAccount(0,4);
                        savingsAccount.currentBalance = 23;
                        do
                        {
                            Console.Write(">> ");
                            input = Console.ReadLine();
                        } while (!(input.ToLower() == "a" || input.ToLower() == "b" || input.ToLower() == "c" || input.ToLower() == "r"));
                        switch (input.ToLower())
                        {
                            case "a":
                                Console.WriteLine("How much money would you like to deposit?");
                                double depositAmount = Double.Parse(Console.ReadLine());
                                savingsAccount.MakeDeposit(depositAmount);
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
                                Console.WriteLine("invalid input");
                                return true;
                        }
                    case "b":
                        Account.ChequingAccount chequingAccount = new Account.ChequingAccount(2, 2);
                        do
                        {
                            Console.WriteLine("Checking Menu\n");
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("A: Deposit\n" +
                                              "B: Withdrawal\n" +
                                              "C: Close + Report\n" +
                                              "R: Return to Bank Menu");
                            Console.ResetColor();
                            Console.Write(">> ");
                            input = Console.ReadLine();
                        } while (!(input.ToLower() == "a" || input.ToLower() == "b" || input.ToLower() == "c" || input.ToLower() == "r"));
                        switch (input.ToLower())
                        {
                            case "a":
                                Console.WriteLine("How much money would you like to deposit?");
                                double depositAmount = Double.Parse(Console.ReadLine());
                                chequingAccount.MakeDeposit(depositAmount);
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
                                Console.WriteLine("invalid input");
                                return true;
                        }
                        return true;
                    case "c":
                        Account.SavingsAccount.GlobalSavingsAccount globalSavingsAccount = new Account.SavingsAccount.GlobalSavingsAccount(2, 2);
                        do
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
                        } while (!(input.ToLower() == "a" || input.ToLower() == "b" || input.ToLower() == "c" || input.ToLower() == "r"));

                        switch (input.ToLower())
                        {
                            case "a":
                                Console.WriteLine("How much money would you like to deposit?");
                                double depositAmount = Double.Parse(Console.ReadLine());
                                globalSavingsAccount.MakeDeposit(depositAmount);
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
                                return true;
                            case "r":
                                return true;
                            default:
                                Console.WriteLine("invalid input");
                                return true;
                        }
                        return true;
                    case "q":
                        Environment.Exit(1);
                        return false;
                }
            } while (!(menuInput.ToLower() == "a" || menuInput.ToLower() == "b" || menuInput.ToLower() == "c" || menuInput.ToLower() == "q"));
            return true;
            Console.ReadLine();
        }
    }
}
