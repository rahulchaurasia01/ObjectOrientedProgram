using Newtonsoft.Json;
using ObjectOrientedProgram.CommercialDataProcessingProgram.GetterSetter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedProgram.CommercialDataProcessingProgram
{
    class StockAccount
    {

        public StockAccount() { }

        /// <summary>
        /// This Constructor will create the new user Account.
        /// </summary>
        /// <param name="filename"></param>
        public StockAccount(string filename)
        {
            List<Customer> customers = Utility.ReadCustomerData();

            string userName;
            bool flag;

            do
            {
                do
                {
                    Console.WriteLine();
                    Console.Write("Enter Your UserName: ");
                    userName = Console.ReadLine();
                    if (!Utility.NameValidation(userName))
                    {
                        Console.WriteLine("Enter Valid UserName. !!");
                        flag = false;
                    }
                    else
                        flag = true;
                } while (!flag);
                if (Utility.IsUserPresent(customers, userName))
                {
                    Console.WriteLine("UserName is Already Taken.");
                    flag = false;
                }
                else
                    flag = true;
            } while (!flag);

            Guid guid = Guid.NewGuid();
            Customer customer = new Customer
            {
                UserName = userName,
                ID = guid.ToString()
            };
            customers.Add(customer);

            CustomerList customerList = new CustomerList
            {
                Customers = customers
            };

            Utility.AddCustomerToJson(customerList);

        }

        /// <summary>
        /// It return the total Amount a Customer is worth.
        /// </summary>
        /// <returns></returns>
        public double ValueOf()
        {
            double totalAmount = 0.0;

            List<CustomerPurchased> customerPurchased1 = Utility.ReadCustomerPurchasedLists();
            customerPurchased1 = customerPurchased1.FindAll(x => x.UserName.Equals(Utility.UserName));
            customerPurchased1 = Utility.AllCustomerPurchasedShare(customerPurchased1);


            foreach (CustomerPurchased customerPurchased in customerPurchased1)
                totalAmount += Convert.ToDouble(customerPurchased.Amount);

            return totalAmount;
        }

        /// <summary>
        /// It Buy the Share for the Customer
        /// </summary>
        /// <param name="amount">Amount of Shares the Customer want to Buy.</param>
        /// <param name="symbol">Name of the Share.</param>
        public void Buy(int amount, string symbol)
        {
            float customerPurchasedShare;
            string TransactionId, userName;

            StockPortfolio stockPortfolio = Utility.SingleStockData(symbol);
            float sharePrice = (float)Convert.ToDouble(stockPortfolio.SharePrice);
            float noOfShare = (float)Convert.ToDouble(stockPortfolio.NoOfShare);

            if (stockPortfolio == null)
            {
                Console.WriteLine("This Share is not present.");
                return;
            }

            customerPurchasedShare = (float)amount / sharePrice;

            if (noOfShare < customerPurchasedShare)
            {
                Console.WriteLine("We Do not Posses this much Share.");
                return;
            }

            Console.WriteLine();
            Console.Write("Are You Sure, Do you want to Buy {0} Share for Rs.{1} [y/n]: ", symbol, amount);

            if (Console.ReadLine().ToLower()[0] == 'n')
                return;
            else
            {
                TransactionId = Guid.NewGuid().ToString();
                userName = Utility.UserName;

                stockPortfolio.NoOfShare = (noOfShare - customerPurchasedShare).ToString();

                List<StockPortfolio> stockPortfolios1 = Utility.ReadStockData(stockPortfolio);

                Stock stock = new Stock
                {
                    Stocks = stockPortfolios1
                };

                Utility.UpdateStockDataToJson(stock);

                List<CustomerPurchased> customerPurchasedLists = Utility.ReadCustomerPurchasedLists();

                CustomerPurchased customerPurchased = new CustomerPurchased
                {
                    Transaction_Id = TransactionId,
                    UserName = userName,
                    ShareName = symbol,
                    NoOfShare = customerPurchasedShare.ToString(),
                    Amount = amount.ToString(),
                    DateAndTime = DateTime.Now.ToString()
                };

                customerPurchasedLists.Add(customerPurchased);

                CustomerPurchasedList customerPurchasedList = new CustomerPurchasedList
                {
                    CustomerPurchaseds = customerPurchasedLists
                };

                Utility.AddCustomerPurchasedShareToJson(customerPurchasedList);

            }

        }

        /*
        public void Sell(int amount, string symbol)
        {
            float customerSoldShare;
            string TransactionId, userName;

            CustomerPurchased customerPurchased1 = Utility.SinglePurchasedData(symbol);
            float sharePrice = (float)Convert.ToDouble(customerPurchased1.Amount);
            float noOfShare = (float)Convert.ToDouble(customerPurchased1.NoOfShare);

            if (customerPurchased1 == null)
            {
                Console.WriteLine("This Share is not present.");
                return;
            }

            customerSoldShare = (float)amount / sharePrice;

            if (noOfShare < customerPurchasedShare)
            {
                Console.WriteLine("We Do not Posses this much Share.");
                return;
            }

            Console.WriteLine();
            Console.Write("Are You Sure, Do you want to Buy {0} Share for Rs.{1} [y/n]: ", symbol, amount);

            if (Console.ReadLine().ToLower()[0] == 'n')
                return;
            else
            {
                TransactionId = Guid.NewGuid().ToString();
                userName = Utility.UserName;

                stockPortfolio.NoOfShare = (noOfShare - customerPurchasedShare).ToString();

                List<StockPortfolio> stockPortfolios1 = Utility.ReadStockData(stockPortfolio);

                Stock stock = new Stock
                {
                    Stocks = stockPortfolios1
                };

                Utility.UpdateStockDataToJson(stock);

                List<CustomerPurchased> customerPurchasedLists = Utility.ReadCustomerPurchasedLists();

                CustomerPurchased customerPurchased = new CustomerPurchased
                {
                    Transaction_Id = TransactionId,
                    UserName = userName,
                    ShareName = symbol,
                    NoOfShare = customerPurchasedShare.ToString(),
                    Amount = amount.ToString(),
                    DateAndTime = DateTime.Now.ToString()
                };

                customerPurchasedLists.Add(customerPurchased);

                CustomerPurchasedList customerPurchasedList = new CustomerPurchasedList
                {
                    CustomerPurchaseds = customerPurchasedLists
                };

                Utility.AddCustomerPurchasedShareToJson(customerPurchasedList);
            }
        }*/
        
        public void Save(string filename)
        {

        }

        public void PrintReport()
        {
            List<CustomerPurchased> customerPurchaseds = Utility.ReadCustomerPurchasedLists();
            customerPurchaseds = customerPurchaseds.FindAll(x => x.UserName.Equals(Utility.UserName));
            if (customerPurchaseds.Count == 0)
            {
                Console.WriteLine("You Have Purchased Anything. ");
                return;
            }

            List<CustomerPurchased> customerPurchaseds2;
            
            int n = ListOfCompanyShares().Count;
            string shareName = "";
            double specificShare = 0.0, totalAmount = 0.0, amount=0.0, totalShare=0.0, tempAmount=0.0;

            int count = 1;
            Console.WriteLine("No.\tShare Name\tNo. Of Share\t\tAmount\t\tTotal Amount");

            for (int i = 0; i < n; i++)
            {
                shareName = ListOfCompanyShares()[i].ShareName;
                amount = Convert.ToDouble(ListOfCompanyShares()[i].SharePrice);
                customerPurchaseds2 = customerPurchaseds.FindAll(x => x.ShareName.Equals(shareName));
                if (customerPurchaseds2.Count != 0)
                {
                    foreach (CustomerPurchased customerPurchased in customerPurchaseds2)
                    {
                        specificShare += Convert.ToDouble(customerPurchased.NoOfShare);
                        totalAmount += Convert.ToDouble(customerPurchased.Amount);

                    }

                    Console.WriteLine(count + "\t" + shareName + "\t\t" + specificShare + "\t\tRs." + amount +"\t\tRs."+ totalAmount);

                    count++;
                    totalShare += specificShare;
                    specificShare = 0.0;
                    tempAmount += totalAmount;
                    totalAmount = 0.0;
                }

            }
            Console.WriteLine();
            Console.WriteLine("The Total Share You Have: {0}", totalShare);
            Console.WriteLine("The Total Amount of Share You Have: Rs.{0}", tempAmount);

            
        }

        /// <summary>
        /// It will read all the stocks data.
        /// </summary>
        /// <returns>List of stocks</returns>
        public static List<StockPortfolio> ListOfCompanyShares()
        {
            string filename = StockReportProgram.StockDataPath;

            string stocksInfoData = File.ReadAllText(filename);

            var stocksInfoObject = JsonConvert.DeserializeObject<Stock>(stocksInfoData);

            List<StockPortfolio> stocks;

            if (stocksInfoObject == null)
                stocks = new List<StockPortfolio>();
            else
                stocks = stocksInfoObject.Stocks;

            return stocks;
        }

    }
}
