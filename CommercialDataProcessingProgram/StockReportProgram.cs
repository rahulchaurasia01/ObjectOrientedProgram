/*
 *  Purpose: Program for storing the list of Stocks with Stocks Details such as Share Name,
 *  No. of Share and Prices of Share.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   23-12-2019
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ObjectOrientedProgram.CommercialDataProcessingProgram
{
    class StockReportProgram
    {
        /// <summary>
        /// This Method is used to test the StockReportProgram Class.
        /// </summary>
        public static void StockReport()
        {

            try
            {
                Console.WriteLine();
                Console.WriteLine("-----------------Commercial Data Processing Program-----------------");

                string customerLoginPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CommercialDataProcessingProgram\Data\CustomerInfo.json";
                string stockDataPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CommercialDataProcessingProgram\Data\StockData.json";
                string loginUserName = "";
                int choice;
                bool flag = false, inputFlag = false;
                StockAccount stockAccount;

                List<Customer> customers = Utility.ReadCustomerData(customerLoginPath);
                Customer customer;

                do
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Create a New Account");
                        Console.WriteLine("2. Login to my Account");
                        Console.WriteLine("3. Exit");
                        Console.Write("Enter your Choice: ");
                        inputFlag = int.TryParse(Console.ReadLine(), out choice);
                        Utility.ErrorMessage(inputFlag);
                    } while (!inputFlag);
                    inputFlag = false;
                    switch (choice)
                    {
                        case 1:
                            stockAccount = new StockAccount(customerLoginPath);
                            Console.WriteLine();
                            Console.WriteLine("Please Login, to Continue.");
                            flag = false;
                            break;

                        case 2:
                            Console.WriteLine();
                            customers = Utility.ReadCustomerData(customerLoginPath);
                            Console.Write("Enter Your UserName: ");
                            loginUserName = Console.ReadLine();
                            if (!Utility.NameValidation(loginUserName))
                            {
                                Console.WriteLine("Enter Valid UserName. !!");
                                flag = false;
                            }
                            else
                            {
                                if (!Utility.IsUserPresent(customers, loginUserName))
                                {
                                    Console.WriteLine("Unable to find the UserName.");
                                    flag = false;
                                }
                                else
                                    flag = true;
                            }
                            break;

                        case 3:
                            return;

                        default:
                            Console.WriteLine("Invalid Choice. !!!");
                            break;
                    }

                } while (!flag);

                int stockChoice, amount;
                string shareName;
                flag = false;
                Console.WriteLine();
                Console.WriteLine("Welcome {0} to the Commercial Data Processing", loginUserName);

                do
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Buy the Shares.");
                        Console.WriteLine("2. Sell the Shares.");
                        Console.WriteLine("3. Exit");
                        Console.Write("Enter your Choice: ");
                        inputFlag = int.TryParse(Console.ReadLine(), out choice);
                        Utility.ErrorMessage(inputFlag);
                    } while (!inputFlag);
                    switch(choice)
                    {
                        case 1:
                            Console.WriteLine();
                            List<StockPortfolio> stockPortfolios = Utility.ReadStocksData(stockDataPath);
                            do
                            {
                                Console.WriteLine("The List of the shares Available are:");
                                Utility.DisplayStocks(stockPortfolios);
                                Console.WriteLine();
                                Console.Write("Enter your Choice: ");
                                inputFlag = int.TryParse(Console.ReadLine(), out stockChoice);
                                Utility.ErrorMessage(inputFlag);
                                if (stockChoice == stockPortfolios.Count + 1)
                                    break;
                            } while (!inputFlag);

                            Console.WriteLine();
                            Console.Write("Enter the Name Of Share you want to Buy: ");
                            shareName = Console.ReadLine();
                            do
                            {
                                Console.Write("Enter the Amount of Share you want to buy: ");
                                inputFlag = int.TryParse(Console.ReadLine(), out amount);
                                Utility.ErrorMessage(inputFlag);
                            } while (!inputFlag);
                            stockAccount = new StockAccount();
                            stockAccount.Buy(amount, shareName);
                            break;

                        case 3:
                            flag = true;
                            break;

                        default:
                            Console.WriteLine("Invalid Choice. !!");
                            break;
                    }
                } while (!flag);

            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

    }
}
