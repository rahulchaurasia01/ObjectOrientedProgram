using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ObjectOrientedProgram.CommercialDataProcessingProgram
{
    class Utility
    {
        /// <summary>
        /// It will read all the Customer Data.
        /// </summary>
        /// <param name="filename">Its a Path where all the customer data is stored.</param>
        /// <returns>List of Customer created.</returns>
        public static List<Customer> ReadCustomerData(string filename)
        {
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
                    return true;
            }
            return false;
        }

        /// <summary>
        /// It will read all the stocks data.
        /// </summary>
        /// <param name="filename">its a path where the data is stored.</param>
        /// <returns>List of stocks</returns>
        public static List<StockPortfolio> ReadStocksData(string filename)
        {
            string stocksInfoData = File.ReadAllText(filename);

            var stocksInfoObject = JsonConvert.DeserializeObject<Stock>(stocksInfoData);

            List<StockPortfolio> stocks;

            if (stocksInfoObject == null)
                stocks = new List<StockPortfolio>();
            else
                stocks = stocksInfoObject.Stocks;

            return stocks;
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
                Console.WriteLine("No.\tShare Name\tNo. Of Share\tShare Price");
                foreach (StockPortfolio stock in stockPortfolios)
                {
                    Console.WriteLine(count + "\t" + stock.ShareName + "\t\t" + stock.NoOfShare + "\t\t" + stock.SharePrice);
                    count++;
                }
                Console.WriteLine(count + ". Exit");
            }
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
