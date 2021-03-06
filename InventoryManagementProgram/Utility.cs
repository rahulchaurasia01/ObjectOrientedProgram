﻿/*
 *  Purpose: The Utility Class is used to store the logic of the Data Structure Program.
 *  
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   20-12-2019
 * 
 */

using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram.InventoryManagementProgram
{
    class Utility
    {
        /// <summary>
        /// It Print the List of inventory Present in the json.
        /// </summary>
        /// <param name="list">It Contains the Inventory List</param>
        /// <param name="stockDepartment">It store the name of the Department Inventory.</param>
        public static void PrintInventory(List<Properties> list, string stockDepartment)
        {
            try
            {
                int count = 1;
                Console.WriteLine();
                Console.WriteLine("\t\t{0}\t\t", stockDepartment);
                var table = new ConsoleTable("No.", "Name", "Weight(kg)", "Rs.Price/Kg");
                if (list == null)
                    Console.WriteLine("No Data Present. !!");
                else
                {
                    foreach (Properties li in list)
                    {
                        table.AddRow(count, li.Name, li.Weight, li.Price);

                        count++;
                    }
                    table.Options.EnableCount = false;
                    table.Write();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// It helps the user to Buy the inventory stocks
        /// </summary>
        /// <param name="list">It Contains the specific Inventory List</param>
        /// <param name="stockDepartment">It store the department name</param>
        /// <returns></returns>
        public static List<Properties> BuyInventory(List<Properties> list, string stockDepartment)
        {
            try
            {
                string Name = "";
                int choice, weight = 0, price = 0, quantity, userPrice = 0, count;
                bool flag, outerFlag = false;
                do
                {
                    count = 1;
                    do
                    {
                        Console.WriteLine();
                        Console.Write("Enter Your Choice: ");
                        flag = int.TryParse(Console.ReadLine(), out choice);
                        ErrorMessage(flag);
                        if (choice > list.Count)
                        {
                            Console.WriteLine("Invalid Choice !!");
                            flag = false;
                        }
                    } while (!flag);
                    foreach (Properties li in list)
                    {
                        if (count == choice)
                        {
                            Name = li.Name;
                            weight = Convert.ToInt32(li.Weight);
                            price = Convert.ToInt32(li.Price);
                            break;
                        }
                        count++;
                    }
                    do
                    {
                        Console.WriteLine("You Choose to buy: {0}", Name);
                        Console.WriteLine("It's Price is: {0}/kg", price);
                        Console.Write("How Much Quantity Do you want to buy: ");
                        flag = int.TryParse(Console.ReadLine(), out quantity);
                        ErrorMessage(flag);
                    } while (!flag);
                    if (quantity > weight)
                    {
                        Console.WriteLine("At present, we dont posses this much quantity.");
                        Console.WriteLine();
                        PrintInventory(list, stockDepartment);
                    }
                    else
                    {
                        userPrice = quantity * price;
                        Console.WriteLine("Your Total Price is: {0}", userPrice);
                        Console.Write("Are you Sure, you want to Buy this item [y/n]: ");
                        if (Console.ReadLine()[0] == 'y')
                        {
                            weight -= quantity;
                            count = 1;
                            foreach (Properties li in list)
                            {
                                if (count == choice)
                                {
                                    li.Weight = weight.ToString();
                                    break;
                                }
                                count++;
                            }
                            Console.WriteLine("Congratulation you have successfully bought this item !!");
                        }


                        Console.Write("Do you want to Contiune Shopping [y/n]: ");
                        if (Console.ReadLine()[0] == 'y')
                        {
                            Console.WriteLine();
                            PrintInventory(list, stockDepartment);
                        }
                        else
                            outerFlag = true;
                    }
                } while (!outerFlag);

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// If the Conversion from string to int is not possible
        /// then it prints the error message.
        /// </summary>
        /// <param name="flag"></param>
        public static void ErrorMessage(bool flag)
        {
            try
            {
                if (!flag)
                    Console.WriteLine("Please Enter the Number. !!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    
    }
}
