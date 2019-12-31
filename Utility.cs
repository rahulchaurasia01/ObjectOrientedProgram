/*
 *  Purpose: The Utility Class is used to store the logic of the Object Oriented Program.
 *  
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   19-12-2019
 * 
 */

using System;

namespace ObjectOrientedProgram
{
    class Utility
    {
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
                    Console.WriteLine("Please Input the Number !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

    }
}
