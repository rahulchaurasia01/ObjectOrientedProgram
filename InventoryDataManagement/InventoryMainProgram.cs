/*
 *  Purpose: Inventory Management Program for Rice, Wheat, Pulses.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   19-12-2019
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace ObjectOrientedProgram.InventoryManagement
{
    class InventoryMainProgram
    {
        /// <summary>
        /// This Method is used to test the InventoryMainProgram Class.
        /// </summary>
        public static void InventoryMain()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("-----------------Inventory Data Management Program-----------------");
                Console.WriteLine();

                Console.WriteLine("Reading data From Json");

                string inputPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\InventoryDataManagement\JsonInventory.json";
                string outputPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\InventoryDataManagement\InventoryPrice.json";

                string jsonData = File.ReadAllText(inputPath);

                var myData = JsonConvert.DeserializeObject<Inventory>(jsonData);

                int totalRiceValue = 0, totalPulsesValue = 0, totalWheatValue = 0;

                List<Properties> rice = myData.Rice;
                foreach (Properties p in rice)
                    totalRiceValue += Convert.ToInt32(p.Weight) * Convert.ToInt32(p.Price);

                List<Properties> pulses = myData.Pulses;
                foreach (Properties p in pulses)
                    totalPulsesValue += Convert.ToInt32(p.Weight) * Convert.ToInt32(p.Price);

                List<Properties> wheats = myData.Wheats;
                foreach (Properties p in wheats)
                    totalWheatValue += Convert.ToInt32(p.Weight) * Convert.ToInt32(p.Price);


                Console.WriteLine("The Value of Rice Inventory is: Rs.{0}", totalRiceValue);
                Console.WriteLine("The Value of Pulses Inventory is: Rs.{0}", totalPulsesValue);
                Console.WriteLine("The Value of Wheat Inventory is: Rs.{0}", totalWheatValue);

                InventoryTotalPrice inventoryTotalPrice = new InventoryTotalPrice();
                Prices ricePrice = new Prices
                {
                    Name = "Rice",
                    Price = totalRiceValue.ToString()
                };

                Prices pulsesPrice = new Prices
                {
                    Name = "Pulses",
                    Price = totalPulsesValue.ToString()
                };

                Prices wheatPrice = new Prices
                {
                    Name = "Wheats",
                    Price = totalWheatValue.ToString()
                };

                inventoryTotalPrice.Prices.Add(ricePrice);
                inventoryTotalPrice.Prices.Add(pulsesPrice);
                inventoryTotalPrice.Prices.Add(wheatPrice);

                string inventoryPriceData = JsonConvert.SerializeObject(inventoryTotalPrice.Prices);

                Console.WriteLine("Writing into the file");

                using StreamWriter streamwriter = new StreamWriter(outputPath);
                streamwriter.WriteLine(inventoryPriceData);

                Console.WriteLine("File Written Successfully.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

    }
}
