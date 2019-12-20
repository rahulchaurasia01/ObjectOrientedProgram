/*
 *  Purpose: Inventory Management Program for Rice, Wheat, Pulses.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   20-12-2019
 */

using Newtonsoft.Json;
using System;
using System.IO;

namespace ObjectOrientedProgram.InventoryManagementProgram
{
    class InventoryManagerProgram
    {
        /// <summary>
        /// This Method is used to test the InventoryMainProgram Class.
        /// </summary>
        public static void InventoryManager()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("-----------------Inventory Management Program-----------------");
                Console.WriteLine();

                Console.WriteLine("Reading data From Json");

                string inputPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\InventoryManagementProgram\JsonInventory.json";
                
                string jsonData = File.ReadAllText(inputPath);

                var myData = JsonConvert.DeserializeObject<Inventory>(jsonData);

                Console.WriteLine();
                Console.WriteLine("Welcome to Bridelabz Bazaar !!!");

                string stockDepartment = "Rice Department.";
                Utility.PrintInventory(myData.Rice, stockDepartment);

                stockDepartment = "Pulses Department.";
                Utility.PrintInventory(myData.Pulses, stockDepartment);

                stockDepartment = "Wheat Department.";
                Utility.PrintInventory(myData.Wheats, stockDepartment);

                int choice;
                bool flag=false, inputFlag;

                do
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("From Which Department You want to Buy.");
                        Console.WriteLine("1. Rice Department");
                        Console.WriteLine("2. Pulses Department");
                        Console.WriteLine("3. Wheat Department");
                        Console.WriteLine("4. Exit");
                        Console.Write("Enter your Choice: ");
                        inputFlag = int.TryParse(Console.ReadLine(), out choice);
                        Utility.ErrorMessage(inputFlag);
                    } while (!inputFlag);
                    switch(choice)
                    {
                        case 1:
                            stockDepartment = "Rice Department";
                            Utility.PrintInventory(myData.Rice, stockDepartment);
                            myData.Rice = Utility.BuyInventory(myData.Rice, stockDepartment);
                            break;

                        case 2:
                            stockDepartment = "Pulses Department";
                            Utility.PrintInventory(myData.Pulses, stockDepartment);
                            myData.Pulses = Utility.BuyInventory(myData.Pulses, stockDepartment);
                            break;

                        case 3:
                            stockDepartment = "Wheats Department";
                            Utility.PrintInventory(myData.Wheats, stockDepartment);
                            myData.Wheats = Utility.BuyInventory(myData.Wheats, stockDepartment);
                            break;

                        case 4:
                            Console.WriteLine("Thanks For Shopping from BridgeLabz Bazaar");
                            flag = true;
                            break;

                        default:
                            Console.WriteLine("Invalid Choice !!");
                            break;

                    }
                } while (!flag);

                Inventory inventory = new Inventory
                {
                    Rice = myData.Rice,
                    Pulses = myData.Pulses,
                    Wheats = myData.Wheats
                };

                string data = JsonConvert.SerializeObject(inventory);

                using (StreamWriter streamwriter = new StreamWriter(inputPath))
                    streamwriter.WriteLine(data);

                Console.WriteLine("Json File Updated.");

            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

    }
}
