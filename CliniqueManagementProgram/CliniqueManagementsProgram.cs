/*
 *  Purpose: Program for booking an Appointment with the doctor and the list of doctor
 *  present and Patients. 
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   28-12-2019
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram.CliniqueManagementProgram
{
    class CliniqueManagementsProgram
    {

        public static string DoctorPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CliniqueManagementProgram\Data\Doctors.json";
        public static string PatientPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CliniqueManagementProgram\Data\Patients.json";

        /// <summary>
        /// This Method is used to test the Clinique Management program class.
        /// </summary>
        public static void CliniqueManagements()
        {


            try
            {

                Console.WriteLine();
                Console.WriteLine("-----------------Clinique Management Program-----------------");




            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }



        }

    }
}
