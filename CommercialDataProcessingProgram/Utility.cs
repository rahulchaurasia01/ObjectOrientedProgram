/*
 *  Purpose: The Utility Class is used to store the logic of the Commercial Data Processing Program.
 *  
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   28-12-2019
 * 
 */

using Newtonsoft.Json;
using ObjectOrientedProgram.CommercialDataProcessingProgram.GetterSetter;
using System;
using System.Collections.Generic;
using System.IO;
using ObjectOrientedProgram.Core;
using System.Text;
using System.Text.RegularExpressions;

namespace ObjectOrientedProgram.CommercialDataProcessingProgram
{
    class Utility
    {
        public static string UserName = null;

        /// <summary>
        /// It will read all the Customer Data.
        /// </summary>
        /// <param name="filename">Its a Path where all the customer data is stored.</param>
        /// <returns>List of Customer created.</returns>
        public static List<Customer> ReadCustomerData()
        {
            string filename = StockReportProgram.customerLoginPath;

            string customerInfoData = File.ReadAllText(filename);

            var customerInfoObject = JsonConvert.DeserializeObject<CustomerList>(customerInfoData);

            List<Customer> customers;
            
            if (customerInfoObject == null)
                customers = new List<Customer>();
            else
                customers = customerInfoObject.Customers;

            return customers;
        }

        /// <summary>
        /// It return true if the username is already created else false.
        /// </summary>
        /// <param name="customers">Customer register to Commercial Data Processing</param>
        /// <param name="userName">user username</param>
        /// <returns></returns>
        public static bool IsUserPresent(List<Customer> customers, string userName)
        {
            foreach (Customer cust in customers)
            {
                if (cust.UserName.Equals(userName))
                {
                    UserName = cust.UserName;
                    return true;
                }
                    
            }
            return false;
        }

        /// <summary>
        /// It will read all the Customer Purchased Data;
        /// </summary>
        /// <returns>List of all Customer Purchased Share</returns>
        public static List<CustomerPurchased> ReadCustomerPurchasedLists()
        {
            string filename = StockReportProgram.customerPurchasedSharePath;
            string customerPurchasedData = File.ReadAllText(filename);

            var customerPurchasedObject = JsonConvert.DeserializeObject<CustomerPurchasedList>(customerPurchasedData);

            List<CustomerPurchased> customerPurchaseds;

            if (customerPurchasedObject == null)
                customerPurchaseds = new List<CustomerPurchased>();
            else
                customerPurchaseds = customerPurchasedObject.CustomerPurchaseds;

            return customerPurchaseds;
        }

        /// <summary>
        /// It Print all the list of stock available.
        /// </summary>
        /// <param name="stockPortfolios">List of stocks Available</param>
        public static void DisplayStocks(List<StockPortfolio> stockPortfolios)
        {
            if(stockPortfolios.Count == 0)
                Console.WriteLine("Currently No Stocks Present.");
            else
            {
                int count = 1;
                Console.WriteLine("No.\tShare Name\tNo. Of Share\t\tShare Price");
                foreach (StockPortfolio stock in stockPortfolios)
                {
                    Console.WriteLine(count + "\t" + stock.ShareName + "\t\t" + stock.NoOfShare + "\t\tRs." + stock.SharePrice);
                    count++;
                }
                Console.WriteLine(count + ". Exit");
            }
        }

        /// <summary>
        /// It Print all the List of Share the Customer Has Brought.
        /// </summary>
        /// <param name="customerPurchaseds"></param>
        public static void DisplayPurchasedShares(List<CustomerPurchased> customerPurchaseds)
        {
            double totalShare = 0.0, totalAmount = 0.0;

            int count = 1;
            Console.WriteLine("No.\tShare Name\tNo. Of Share\t\tAmount");

            foreach (CustomerPurchased customerPurchased in customerPurchaseds)
            {
                Console.WriteLine(count + "\t" + customerPurchased.ShareName + "\t\t" + customerPurchased.NoOfShare + "\t\tRs." + customerPurchased.Amount);
                totalShare += Convert.ToDouble(customerPurchased.NoOfShare);
                totalAmount += Convert.ToDouble(customerPurchased.Amount);
                count++;
            }

            Console.WriteLine("\t \t\t----------\t\t----------");
            Console.WriteLine("Total: \t \t \t{0} \t\tRs.{1}", totalShare, totalAmount);


        }
        
        /// <summary>
        /// It Added All the Share Purchased in parts.
        /// </summary>
        /// <param name="customerPurchaseds"></param>
        /// <returns></returns>
        public static List<CustomerPurchased> AllCustomerPurchasedShare(List<CustomerPurchased> customerPurchaseds)
        {
            List<CustomerPurchased> customerPurchaseds1 = new List<CustomerPurchased>();
            List<CustomerPurchased> customerPurchaseds2;
            CustomerPurchased customerPurchased1;
            int n = StockAccount.ListOfCompanyShares().Count;
            string shareName = "";
            double specificShare = 0.0, amount = 0.0;

            if (customerPurchaseds.Count == 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    shareName = StockAccount.ListOfCompanyShares()[i].ShareName;
                    customerPurchaseds2 = customerPurchaseds.FindAll(x => x.ShareName.Equals(shareName));
                    if (customerPurchaseds2.Count != 0)
                    {
                        foreach (CustomerPurchased customerPurchased in customerPurchaseds2)
                        {
                            specificShare += Convert.ToDouble(customerPurchased.NoOfShare);
                            amount += Convert.ToDouble(customerPurchased.Amount);

                        }
                        customerPurchased1 = new CustomerPurchased
                        {
                            ShareName = shareName,
                            NoOfShare = specificShare.ToString(),
                            Amount = amount.ToString()
                        };
                        customerPurchaseds1.Add(customerPurchased1);
                        specificShare = 0.0;
                        amount = 0.0;
                    }

                }
                return customerPurchaseds1;
            }
        }

        /// <summary>
        /// Add New Customer To the json File.
        /// </summary>
        /// <param name="customerList">List Of Customers</param>
        public static void AddCustomerToJson(CustomerList customerList)
        {
            string filename = StockReportProgram.customerLoginPath;

            string customerData = JsonConvert.SerializeObject(customerList);

            using (StreamWriter streamWriter = new StreamWriter(filename))
                streamWriter.WriteLine(customerData);

            Console.WriteLine("Your Account Has Been Successfully Created.");
        }

        /// <summary>
        /// Add new Purchased Share to Json
        /// </summary>
        /// <param name="customerPurchasedList"></param>
        public static void AddCustomerPurchasedShareToJson(CustomerPurchasedList customerPurchasedList)
        {
            string filename = StockReportProgram.customerPurchasedSharePath;
            
            string customerPurchasedData = JsonConvert.SerializeObject(customerPurchasedList);

            using (StreamWriter streamWriter = new StreamWriter(filename))
                streamWriter.WriteLine(customerPurchasedData);

            Console.WriteLine("Your Have Successfully Brought this Share.");

        }

        /// <summary>
        /// Add new Sold Share to Json
        /// </summary>
        /// <param name="customerSoldList">Customer sold Share Data.</param>
        public static void AddCustomerSoldShareToJson(CustomerSoldList customerSoldList)
        {
            string filename = StockReportProgram.customerSoldSharePath;

            string customerSoldData = JsonConvert.SerializeObject(customerSoldList);

            using (StreamWriter streamWriter = new StreamWriter(filename))
                streamWriter.WriteLine(customerSoldData);

            Console.WriteLine("Your Have Successfully Sold this Share.");

        }

        /// <summary>
        /// Update the Stock Details After User Brought the Share.
        /// </summary>
        /// <param name="stock"></param>
        public static void UpdateStockDataToJson(Stock stock)
        {
            string filename = StockReportProgram.StockDataPath;

            string updateStockData = JsonConvert.SerializeObject(stock);

            using StreamWriter streamWriter = new StreamWriter(filename);
            streamWriter.WriteLine(updateStockData);

        }

        /// <summary>
        /// it will read all the stocks Data
        /// </summary>
        /// <param name="stockPortfolio"></param>
        /// <returns></returns>
        public static List<StockPortfolio> ReadStockData(StockPortfolio stockPortfolio)
        {
            List<StockPortfolio> stockPortfolios = StockAccount.ListOfCompanyShares();

            if(stockPortfolios != null)
            {
                foreach(StockPortfolio stockPortfolio1 in stockPortfolios)
                {
                    if (stockPortfolio1.ShareName.Equals(stockPortfolio.ShareName))
                    {
                        stockPortfolio1.NoOfShare = stockPortfolio.NoOfShare;
                        return stockPortfolios;
                    }
                }
            }

            return null;

        }

        /// <summary>
        /// It return Single Share Data.
        /// </summary>
        /// <param name="symbol"></param>
        /// <returns></returns>
        public static StockPortfolio SingleStockData(string symbol)
        {
            List<StockPortfolio> stockPortfolios = StockAccount.ListOfCompanyShares();

            if(stockPortfolios.Count != 0)
            {
                foreach (StockPortfolio stockPortfolio in stockPortfolios)
                {
                    if (stockPortfolio.ShareName.Equals(symbol))
                        return stockPortfolio;
                }
            }

            return null;

        }


        public static void DisplayTransaction()
        {
            List<CustomerPurchased> customerPurchaseds = ReadCustomerPurchasedLists();
            customerPurchaseds = customerPurchaseds.FindAll(x => x.UserName.Equals(UserName));

            QueueLinkedList queueLinkedList = new QueueLinkedList();

            bool inputFlag;
            int choice;

            DisplayPurchasedShares(customerPurchaseds);

            do
            {
                Console.WriteLine();
                Console.Write("Which Share Transaction you want to view: ");
                inputFlag = int.TryParse(Console.ReadLine(), out choice);
                ErrorMessage(inputFlag);
                if (!inputFlag)
                    DisplayPurchasedShares(customerPurchaseds);
                if (choice <= 0 || choice > customerPurchaseds.Count)
                {
                    Console.WriteLine("Invalid Choice !!!");
                    DisplayPurchasedShares(customerPurchaseds);
                    Console.WriteLine();
                    inputFlag = false;
                }

            } while (!inputFlag);

            foreach (CustomerPurchased customerPurchased in customerPurchaseds)
                queueLinkedList.Enqueue(customerPurchased.DateAndTime);

            Console.WriteLine("The Transaction Date is: {0}", queueLinkedList.Search(choice));

        }

        /// <summary>
        /// It return true If the validation Matches the pattern.
        /// </summary>
        /// <param name="name">Its a string</param>
        /// <returns></returns>
        public static bool NameValidation(string userName)
        {
            string pattern = @"^[a-zA-Z0-9]{3,15}$";
            return Regex.IsMatch(userName, pattern);
        }

        /// <summary>
        /// If the Conversion from string to int is not possible
        /// then it prints the error message.
        /// </summary>
        /// <param name="flag"></param>
        public static void ErrorMessage(bool flag)
        {
            if (!flag)
                Console.WriteLine("Please Input the Number !!!");
        }

    }
}
