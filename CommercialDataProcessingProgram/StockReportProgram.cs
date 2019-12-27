/*
 *  Purpose: Program for storing the list of Stocks with Stocks Details such as Share Name,
 *  No. of Share and Prices of Share.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   23-12-2019
 */


using Newtonsoft.Json;
using ObjectOrientedProgram.CommercialDataProcessingProgram.GetterSetter;
using System;
using System.Collections.Generic;
using System.IO;

namespace ObjectOrientedProgram.CommercialDataProcessingProgram
{
    class StockReportProgram
    {

        public static string customerLoginPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CommercialDataProcessingProgram\Data\CustomerInfo.json";
        public static string customerPurchasedSharePath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CommercialDataProcessingProgram\Data\CustomerPurchasedInfo.json";
        public static string StockDataPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CommercialDataProcessingProgram\Data\StockData.json";
        public static string customerSoldSharePath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CommercialDataProcessingProgram\Data\CustomerSoldInfo.json";

        /// <summary>
        /// This Method is used to test the StockReportProgram Class.
        /// </summary>
        public static void StockReport()
        {

            try
            {
                Console.WriteLine();
                Console.WriteLine("-----------------Commercial Data Processing Program-----------------");

                string loginUserName = "";
                int choice;
                bool flag = false, inputFlag = false;
                StockAccount stockAccount;

                List<Customer> customers = Utility.ReadCustomerData();

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
                            customers = Utility.ReadCustomerData();
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

                int amount, count;
                string shareName=null;
                flag = false;
                Console.WriteLine();
                Console.WriteLine("Welcome {0} to the Commercial Data Processing", loginUserName);

                do
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Your Account Value.");
                        Console.WriteLine("2. Buy the Shares.");
                        Console.WriteLine("3. Sell the Shares.");
                        Console.WriteLine("4. Display Transaction");
                        Console.WriteLine("5. Print Report.");
                        Console.WriteLine("6. Exit");
                        Console.Write("Enter your Choice: ");
                        inputFlag = int.TryParse(Console.ReadLine(), out choice);
                        Utility.ErrorMessage(inputFlag);
                    } while (!inputFlag);
                    switch(choice)
                    {

                        case 1:
                            Console.WriteLine();
                            stockAccount = new StockAccount();
                            Console.WriteLine("Your Account Worth is: Rs.{0}", stockAccount.ValueOf());
                            break;

                        case 2:
                            List<StockPortfolio> stockPortfolios = StockAccount.ListOfCompanyShares();
                            
                            do
                            {
                                count = 1;
                                Console.WriteLine();
                                Console.WriteLine("The List of the shares Available are:");
                                Utility.DisplayStocks(stockPortfolios);
                                Console.WriteLine();
                                Console.Write("Enter your Choice: ");
                                inputFlag = int.TryParse(Console.ReadLine(), out int stockChoice);
                                Utility.ErrorMessage(inputFlag);
                                if (stockChoice == (stockPortfolios.Count + 1))
                                    break;
                                if (stockChoice <= 0 || stockChoice > stockPortfolios.Count + 1)
                                {
                                    Console.WriteLine("Invalid Choice !!");
                                    inputFlag = false;
                                }
                                else
                                {
                                    inputFlag = true;
                                    foreach (StockPortfolio stockPortfolio in stockPortfolios)
                                    {
                                        if (count == stockChoice)
                                        {
                                            shareName = stockPortfolio.ShareName;
                                            break;
                                        }
                                        count++;
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("You choose to buy the {0} Share", shareName);
                                    do
                                    {
                                        Console.Write("Enter the Amount of {0} Share you want to buy: ", shareName);
                                        inputFlag = int.TryParse(Console.ReadLine(), out amount);
                                        Utility.ErrorMessage(inputFlag);
                                    } while (!inputFlag);
                                    stockAccount = new StockAccount();
                                    stockAccount.Buy(amount, shareName);
                                    
                                }
                                
                            } while (!inputFlag);
                            break;

                        case 3:
                            List<CustomerPurchased> customerPurchaseds = Utility.ReadCustomerPurchasedLists();
                            customerPurchaseds = customerPurchaseds.FindAll(x => x.UserName.Equals(Utility.UserName));
                            do
                            {
                                count = 1;
                                Console.WriteLine();
                                customerPurchaseds = Utility.AllCustomerPurchasedShare(customerPurchaseds);
                                if (customerPurchaseds == null)
                                {
                                    Console.WriteLine("Currently You Have Purchased Nothing.");
                                    break;
                                }
                                Console.WriteLine("The List of the shares you have brought are:");
                                Utility.DisplayPurchasedShares(customerPurchaseds);
                                Console.WriteLine();
                                Console.WriteLine("Which Share You want to Sell.");
                                Console.Write("Enter your Choice: ");
                                inputFlag = int.TryParse(Console.ReadLine(), out int stockSoldChoice);
                                Utility.ErrorMessage(inputFlag);
                                
                                if (stockSoldChoice <= 0 || stockSoldChoice > customerPurchaseds.Count)
                                {
                                    Console.WriteLine("Invalid Choice !!");
                                    inputFlag = false;
                                }
                                else
                                {
                                    inputFlag = true;
                                    foreach (CustomerPurchased customerPurchased in customerPurchaseds)
                                    {
                                        if (count == stockSoldChoice)
                                        {
                                            shareName = customerPurchased.ShareName;
                                            break;
                                        }
                                        count++;

                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("You choose to sold the {0} Share", shareName);
                                    do
                                    {
                                        Console.Write("Enter the Amount of {0} Share you want to sold: ", shareName);
                                        inputFlag = int.TryParse(Console.ReadLine(), out amount);
                                        Utility.ErrorMessage(inputFlag);
                                    } while (!inputFlag);
                                    stockAccount = new StockAccount();
                                    //stockAccount.Sell(amount, shareName);

                                }

                            } while (!inputFlag);
                            break;

                        case 4:
                            Console.WriteLine();
                            Utility.DisplayTransaction();
                            break;

                        case 5:
                            Console.WriteLine();
                            stockAccount = new StockAccount();
                            stockAccount.PrintReport();
                            break;

                        case 6:
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
