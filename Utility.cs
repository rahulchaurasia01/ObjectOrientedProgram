/*
 *  Purpose: The Utility Class is used to store the logic of the Data Structure Program.
 *  
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   19-12-2019
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram
{
    class Utility
    {

        public static void ErrorMessage(bool flag)
        {
            if (!flag)
                Console.WriteLine("Please Input the Number !!!");
        }

    }
}
