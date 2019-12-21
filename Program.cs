﻿/*
 *  Purpose: Entry Point For the Program.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   19-12-2019
 */

using ObjectOrientedProgram.InventoryDataManagement;
using ObjectOrientedProgram.InventoryManagementProgram;
using ObjectOrientedProgram.RegularExpression;
using ObjectOrientedProgram.StockReportsProgram;
using System;

namespace ObjectOrientedProgram
{
    class Program
    {
        static void Main()
        {
            try
            {
                bool flag;
                int choice;

                do
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Welcome to BridgeLabz");
                        Console.WriteLine();
                        Console.WriteLine("1. Inventory Data Management Program");
                        Console.WriteLine("2. Regular Expression Program");
                        Console.WriteLine("3. Stock Report Program");
                        Console.WriteLine("4. Inventory Management Program");
                        Console.WriteLine("5. Exit");
                        Console.Write("Enter Your Choice: ");
                        flag = int.TryParse(Console.ReadLine(), out choice);
                        Utility.ErrorMessage(flag);
                    } while (!flag);
                    flag = false;
                    switch (choice)
                    {
                        case 1:
                            InventoryMainProgram.InventoryMain();
                            break;

                        case 2:
                            RegularExpressionProgram.RegularExpression();
                            break;

                        case 3:
                            StockReportProgram.StockReport();
                            break;

                        case 4:
                            InventoryManagerProgram.InventoryManager();
                            break;

                        case 5:
                            flag = true;
                            break;

                        default:
                            Console.WriteLine("Invalid Choice !!!");
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
