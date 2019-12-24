using Newtonsoft.Json;
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
            List<Customer> customers = Utility.ReadCustomerData(filename);

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

            string customerData = JsonConvert.SerializeObject(customerList);

            using (StreamWriter streamWriter = new StreamWriter(filename))
                streamWriter.WriteLine(customerData);

            Console.WriteLine("Your Account Has Been Successfully Created.");

        }

        public double ValueOf()
        {
            return 0.0;
        }

        public void Buy(int amount, string symbol)
        {
            Console.WriteLine("HOla");
        }

        public void Sell(int amount, string symbol)
        {

        }

        public void Save(string filename)
        {

        }

        public void PrintReport()
        {

        }

    }
}
