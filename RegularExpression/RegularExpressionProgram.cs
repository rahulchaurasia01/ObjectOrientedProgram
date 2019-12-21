/*
 *  Purpose: Program to implement the regular Expression.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   21-12-2019
 */

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ObjectOrientedProgram.RegularExpression
{
    class RegularExpressionProgram
    {
        /// <summary>
        /// This Method is used to test the RegularExpressionProgram Class.
        /// </summary>
        public static void RegularExpression()
        {
            try
            {

                Console.WriteLine();
                Console.WriteLine("-----------------Regular Expression Program-----------------");
                Console.WriteLine();

                string inputPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\RegularExpression\InputMessage.txt";
                string outputPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\RegularExpression\OutputMessage.txt";

                Console.WriteLine("Reading data from File. !!");

                string inputData = File.ReadAllText(inputPath);

                Console.WriteLine("Done Reading from File");

                string name, fullname;
                long mobileNumber;
                bool flag;

                Console.WriteLine();
                Console.Write("Enter Your Name: ");
                name = Console.ReadLine();

                Console.Write("Enter Your Full Name: ");
                fullname = Console.ReadLine();

                do
                {
                    Console.Write("Enter Your Mobile Number: ");
                    flag = long.TryParse(Console.ReadLine(), out mobileNumber);
                    Utility.ErrorMessage(flag);
                    if (!flag)
                        Console.WriteLine();
                    else
                    {
                        string str = mobileNumber + "";
                        if (str.Length != 10)
                        {
                            Console.WriteLine("Mobile Number should be of 10 digit");
                            flag = false;
                        }
                    }
                } while (!flag);

                string pattern = @"\<+\b[a-z]+\>+";
                inputData = Regex.Replace(inputData, pattern, name);

                pattern = @"\<+[a-z]+\s?[a-z]+\>+";
                inputData = Regex.Replace(inputData, pattern, fullname);

                pattern = @"\b[x]+\b";
                inputData = Regex.Replace(inputData, pattern, mobileNumber.ToString());

                pattern = @"\d{2}\/\d{2}\/\d{4}";
                inputData = Regex.Replace(inputData, pattern, DateTime.Now.ToShortDateString());

                Console.WriteLine();
                Console.WriteLine(inputData);

                using (StreamWriter streamWriter = new StreamWriter(outputPath))
                {
                    streamWriter.WriteLine(inputData);
                }

                Console.WriteLine();
                Console.WriteLine("The File has been Updated with recent Data.");

            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    }
}
