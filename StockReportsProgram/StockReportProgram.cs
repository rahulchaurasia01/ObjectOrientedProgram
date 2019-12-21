/*
 *  Purpose: Program for storing the list of Stocks with Stocks Details such as Share Name,
 *  No. of Share and Prices of Share.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   21-12-2019
 */


using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ObjectOrientedProgram.StockReportsProgram
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
                Console.WriteLine("-----------------Stock Report Generator Program-----------------");

                bool flag;
                int noOfStock, noOfShare, sharePrice, totalStock = 0;
                string outputPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\StockReportsProgram\StockData.json";

                List<StockPortfolio> stocks = new List<StockPortfolio>();

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter the No Of Stock: ");
                    flag = int.TryParse(Console.ReadLine(), out noOfStock);
                    Utility.ErrorMessage(flag);
                } while (!flag);
                for (int i = 0; i < noOfStock; i++)
                {
                    StockPortfolio stockPortfolio = new StockPortfolio();

                    Console.WriteLine();
                    Console.Write("Enter the Share Name: ");
                    stockPortfolio.ShareName = Console.ReadLine();

                    do
                    {
                        Console.Write("Enter the No. of share you have: ");
                        flag = int.TryParse(Console.ReadLine(), out noOfShare);
                        Utility.ErrorMessage(flag);
                        if (!flag)
                            Console.WriteLine();
                    } while (!flag);
                    stockPortfolio.NoOfShare = noOfShare.ToString();

                    do
                    {
                        Console.Write("Enter the share Price for {0}: ", stockPortfolio.ShareName);
                        flag = int.TryParse(Console.ReadLine(), out sharePrice);
                        Utility.ErrorMessage(flag);
                        if (!flag)
                            Console.WriteLine();
                    } while (!flag);
                    stockPortfolio.SharePrice = sharePrice.ToString();

                    totalStock += noOfShare * sharePrice;

                    stocks.Add(stockPortfolio);
                }

                Console.WriteLine();
                Console.WriteLine("The Total Value of ur Stock is: Rs.{0}", totalStock);

                Console.WriteLine();
                Console.WriteLine("Reports Of Stocks !!!");
                foreach (StockPortfolio portfolio in stocks)
                    Console.WriteLine("Share Name: {0}, Total Value of your Share is Rs.{1}", portfolio.ShareName, Convert.ToInt32(portfolio.NoOfShare) * Convert.ToInt32(portfolio.SharePrice));

                Stock stock = new Stock
                {
                    Stocks = stocks
                };

                string stockJsonData = JsonConvert.SerializeObject(stock);

                using StreamWriter streamWriter = new StreamWriter(outputPath);
                streamWriter.WriteLine(stockJsonData);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

    }
}
