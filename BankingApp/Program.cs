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
            string menuInput;
            Console.WriteLine("Bank Menu\n");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("A: Savings\n" +
                              "B: Checking\n" +
                              "C: GlobalSavings\n" +
                              "Q: Exit");
            Console.ResetColor();
            Console.Write(">> ");

            menuInput = Console.ReadLine();
            string input;
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
                    Console.Write(">> ");
                    input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "a":
                            break;
                        case "b":
                            break;
                        case "c":
                            break;
                        case "r":
                            break;
                        default:
                            Console.WriteLine("invalid input");
                            break;
                    }
                    break;
                case "b":
                    Console.WriteLine("Checking Menu\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("A: Deposit\n" +
                                      "B: Withdrawal\n" +
                                      "C: Close + Report\n" +
                                      "R: Return to Bank Menu");
                    Console.ResetColor();
                    Console.Write(">> ");
                    input = Console.ReadLine();
                    switch (input.ToLower())
                    {
                        case "a":
                            break;
                        case "b":
                            break;
                        case "c":
                            break;
                        case "r":
                            break;
                        default:
                            Console.WriteLine("invalid input");
                            break;
                    }
                    break;
                case "c":
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
                    switch (input.ToLower())
                    {
                        case "a":
                            break;
                        case "b":
                            break;
                        case "c":
                            break;
                        case "d":
                            break;
                        case "r":
                            break;
                        default:
                            Console.WriteLine("invalid input");
                            break;
                    }
                    break;
                case "q":
                    Environment.Exit(1);
                    break;
            }
            Console.ReadLine();
        }
    }
}
