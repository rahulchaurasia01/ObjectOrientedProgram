/*
 *  Purpose: Program for booking an Appointment with the doctor and the list of doctor
 *  present and Patients. 
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   28-12-2019
 */

using ObjectOrientedProgram.CliniqueManagementProgram.GetterSetter;
using ObjectOrientedProgram.CliniqueManagementProgram.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram.CliniqueManagementProgram
{
    class CliniqueManagementsProgram
    {

        public static string DoctorPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CliniqueManagementProgram\Data\Doctors.json";
        public static string PatientPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CliniqueManagementProgram\Data\Patients.json";
        public static string AppointmentPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\CliniqueManagementProgram\Data\AppointmentDetails.json";

        /// <summary>
        /// This Method is used to test the Clinique Management program class.
        /// </summary>
        public static void CliniqueManagements()
        {


            try
            {

                Console.WriteLine();
                Console.WriteLine("-----------------Clinique Management Program-----------------");

                Console.WriteLine(DateTime.Today.ToString("dd/MM/yyyy"));
                List<Doctor> doctors = Core.Utility.ReadDoctorJsonFile();
                List<Patient> patients = Core.Utility.ReadPatientJsonFile();

                Doctor doctor;
                Patient patient;

                bool flag = false, inputFlag;
                int choice;

                do
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("1. Create Doctor Account");
                        Console.WriteLine("2. Create Patient Account");
                        Console.WriteLine("3. Search Doctor");
                        Console.WriteLine("4. Search Patient");
                        Console.WriteLine("5. Book an Appointment With the Doctor");
                        Console.WriteLine("6. Exit");
                        Console.Write("Enter your Choice: ");
                        inputFlag = int.TryParse(Console.ReadLine(), out choice);
                        Utility.ErrorMessage(inputFlag);
                    } while (!inputFlag);
                    switch(choice)
                    {
                        case 1:
                            doctor = Core.Utility.CreateDoctor();
                            doctors.Add(doctor);
                            Core.Utility.UpdateDoctorToJson(doctors);
                            Console.WriteLine("Doctor Account has Been Successfully Created.");
                            break;

                        case 2:
                            patient = Core.Utility.CreatePatient();
                            patients.Add(patient);
                            Core.Utility.UpdatePatientToJson(patients);
                            Console.WriteLine("Patient Account has been Successfully Created.");
                            break;

                        case 3:
                            Console.WriteLine();
                            Core.Utility.DisplayAllDoctor(doctors);
                            Core.Utility.DisplayUserQueryDoctor(doctors);
                            break;

                        case 4:
                            Console.WriteLine();
                            Core.Utility.DisplayAllPatient(patients);
                            Core.Utility.DisplayUserQueryPatient(patients);
                            break;

                        case 5:
                            Core.Utility.CreateAppointment();
                            break;

                        case 6:
                            flag = true;
                            break;

                        default:
                            Console.WriteLine("Invalid Choice. !!");
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
