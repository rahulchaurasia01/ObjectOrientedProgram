/*
 *  Purpose: The Utility Class is used to store the logic of the Clinique Management Program.
 *  
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   28-12-2019
 * 
 */

using ConsoleTables;
using Newtonsoft.Json;
using ObjectOrientedProgram.CliniqueManagementProgram.GetterSetter;
using System;
using System.Collections.Generic;
using System.IO;

namespace ObjectOrientedProgram.CliniqueManagementProgram.Core
{
    class Utility
    {
        /// <summary>
        /// It Read the Json File Of Doctor.
        /// </summary>
        /// <returns>It Return the List Of Doctor in the Hospital</returns>
        public static List<Doctor> ReadDoctorJsonFile()
        {
            try
            {
                string filename = CliniqueManagementsProgram.DoctorPath;

                string doctorData = File.ReadAllText(filename);

                var DoctorObject = JsonConvert.DeserializeObject<Doctors>(doctorData);

                List<Doctor> doctors;

                if (DoctorObject == null)
                    doctors = new List<Doctor>();
                else
                    doctors = DoctorObject.GetDoctors;

                return doctors;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }

        }

        /// <summary>
        /// It Read the Json File Of Patient.
        /// </summary>
        /// <returns>It Return the List of Patient who have Visited the Hospital</returns>
        public static List<Patient> ReadPatientJsonFile()
        {
            try
            {
                string filename = CliniqueManagementsProgram.PatientPath;

                string patientData = File.ReadAllText(filename);

                var PatientObject = JsonConvert.DeserializeObject<Patients>(patientData);

                List<Patient> patients;

                if (PatientObject == null)
                    patients = new List<Patient>();
                else
                    patients = PatientObject.GetPatients;

                return patients;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }
        
        /// <summary>
        /// It Read the Json File Of Appointment
        /// </summary>
        /// <returns></returns>
        public static List<Appointment> ReadAppointmentjsonFile()
        {
            try
            {
                string filename = CliniqueManagementsProgram.AppointmentPath;

                string appointmentData = File.ReadAllText(filename);

                var appointmentObject = JsonConvert.DeserializeObject<Appointments>(appointmentData);

                List<Appointment> appointments;

                if (appointmentObject == null)
                    appointments = new List<Appointment>();
                else
                    appointments = appointmentObject.GetAppointments;

                return appointments;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It Create a New Appointment for Patient with doctor.
        /// </summary>
        /// <returns>It return the Doctor Object</returns>
        public static void CreateAppointment()
        {
            try
            {
                string appointmentId, appointmentDateTime;

                int doctorId, patientId;

                bool flag;

                List<Appointment> appointments = ReadAppointmentjsonFile();
                Appointment appointment;
                List<PatientAppointment> patientAppointments;
                PatientAppointment patientAppointment;

                appointmentId = Guid.NewGuid().ToString();

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter the Doctor Id: ");
                    flag = int.TryParse(Console.ReadLine(), out doctorId);
                    ErrorMessage(flag);
                } while (!flag);

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter the Patient Id: ");
                    flag = int.TryParse(Console.ReadLine(), out patientId);
                    ErrorMessage(flag);
                } while (!flag);

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter the Date for Appointment [dd/MM/yyyy]: ");
                    appointmentDateTime = Console.ReadLine();
                    flag = CliniqueManagementValidation.PatientAppointmentValidation(appointmentDateTime);
                    if (!flag)
                        Console.WriteLine("Please Input the Proper Time");
                    else
                    {
                        if (appointments.Count != 0)
                        {
                            foreach (Appointment appointment1 in appointments)
                            {
                                if (appointment1.DoctorId.Equals(doctorId.ToString()) && appointment1.AppointmentDateAndTime.Equals(appointmentDateTime.ToString()))
                                {
                                    if (appointment1.GetPatientAppointments.Count == 5)
                                    {
                                        Console.WriteLine("This Day Slot is full, Please Choose Different Day to Book an Appointment.");
                                        flag = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                } while (!flag);

                if (appointments.Count != 0)
                {
                    foreach (Appointment appointment1 in appointments)
                    {
                        if (appointment1.DoctorId.Equals(doctorId.ToString()) && appointment1.AppointmentDateAndTime.Equals(appointmentDateTime.ToString()))
                        {
                            patientAppointments = appointment1.GetPatientAppointments;
                            patientAppointment = new PatientAppointment
                            {
                                AppointmentId = appointmentId,
                                PatientId = patientId.ToString()
                            };
                            patientAppointments.Add(patientAppointment);
                            appointment1.GetPatientAppointments = patientAppointments;
                            UpdateAppointmentToJson(appointments);

                            return;
                        }
                    }
                }
                appointment = new Appointment
                {
                    DoctorId = doctorId.ToString(),
                    AppointmentDateAndTime = appointmentDateTime
                };
                patientAppointments = new List<PatientAppointment>();
                patientAppointment = new PatientAppointment
                {
                    AppointmentId = appointmentId,
                    PatientId = patientId.ToString()
                };
                patientAppointments.Add(patientAppointment);
                appointment.GetPatientAppointments = patientAppointments;
                appointments.Add(appointment);
                UpdateAppointmentToJson(appointments);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// It Create a New Doctor Account.
        /// </summary>
        /// <returns>It return the Doctor Object</returns>
        public static Doctor CreateDoctor()
        {
            try
            {
                string id, name, specialization, availablity = "";

                Doctor doctor = new Doctor();

                bool flag;

                id = CreateId();

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter the Name: ");
                    name = Console.ReadLine();
                    flag = CliniqueManagementValidation.DoctorNameValidation(name);
                    if (!flag)
                        Console.WriteLine("Please Input the Name");
                } while (!flag);

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter the Specialization: ");
                    specialization = Console.ReadLine();
                    flag = CliniqueManagementValidation.DoctorSpecializationValidation(specialization);
                    if (!flag)
                        Console.WriteLine("Please Input the Specialization");
                } while (!flag);

                do
                {
                    Console.WriteLine();
                    Console.WriteLine("Choose the Availability: ");
                    Console.WriteLine("1. At Morining, i.e Am");
                    Console.WriteLine("2. At Evening, i.e Pm");
                    Console.WriteLine("3. Both");
                    Console.Write("Enter Your Choice: ");
                    flag = int.TryParse(Console.ReadLine(), out int choice);
                    ErrorMessage(flag);
                    if (flag)
                    {
                        switch (choice)
                        {
                            case 1:
                                availablity = "Am";
                                break;

                            case 2:
                                availablity = "Pm";
                                break;

                            case 3:
                                availablity = "Both";
                                break;

                            default:
                                Console.WriteLine("Invalid Choice");
                                flag = false;
                                break;
                        }
                    }

                } while (!flag);

                doctor.DoctorId = id;
                doctor.Name = name;
                doctor.Specialization = specialization;
                doctor.Availability = availablity;

                return doctor;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It Create a New Patient Account.
        /// </summary>
        /// <returns>It return the Object of Patient</returns>
        public static Patient CreatePatient()
        {
            try
            {
                string id, name, mobileNumber, Age;

                Patient patient = new Patient();

                bool flag;

                id = CreateId();

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter the Name: ");
                    name = Console.ReadLine();
                    flag = CliniqueManagementValidation.PatientNameValidation(name);
                    if (!flag)
                        Console.WriteLine("Please Input the Name");
                } while (!flag);

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter the Mobile Number: ");
                    mobileNumber = Console.ReadLine();
                    flag = CliniqueManagementValidation.PatientMobileNumber(mobileNumber);
                    if (!flag)
                        Console.WriteLine("Please Input the Mobile Number");
                } while (!flag);

                do
                {
                    Console.WriteLine();
                    Console.Write("Enter Your Age: ");
                    Age = Console.ReadLine();
                    flag = CliniqueManagementValidation.PatientAgeValidation(Age);
                    if (!flag)
                        Console.WriteLine("Please Input the Age");

                } while (!flag);

                patient.PatientId = id;
                patient.Name = name;
                patient.MobileNumber = mobileNumber;
                patient.Age = Age;

                return patient;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It Create the Unique Id for Doctor and Patient
        /// </summary>
        /// <returns></returns>
        public static string CreateId()
        {
            try
            {
                Random random = new Random();
                List<Doctor> doctors = ReadDoctorJsonFile();
                List<Patient> patients = ReadPatientJsonFile();

                List<string> id = new List<string>();

                if (doctors != null)
                {
                    foreach (Doctor doctor in doctors)
                        id.Add(doctor.DoctorId);
                }

                if (patients != null)
                {
                    foreach (Patient patient in patients)
                        id.Add(patient.PatientId);
                }


                string UniqueId;
                bool flag;
                do
                {
                    UniqueId = random.Next(000000, 999999).ToString();
                    if (!id.Contains(UniqueId))
                        return UniqueId;

                    flag = false;
                } while (!flag);
                return UniqueId;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It Display the Doctor List
        /// </summary>
        /// <param name="doctors">List of Doctors</param>
        public static void DisplayAllDoctor(List<Doctor> doctors)
        {
            try
            {
                if (doctors.Count == 0)
                    Console.WriteLine("No Data Present.");
                else
                {
                    int count = 1;
                    var table = new ConsoleTable("No.", "Id", "Name", "Specialization", "Availability");
                    foreach (Doctor doctor in doctors)
                    {
                        table.AddRow(count, doctor.DoctorId, doctor.Name, doctor.Specialization, doctor.Availability);
                        count++;
                    }
                    table.Options.EnableCount = false;
                    table.Write();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message); 
            }
        }

        /// <summary>
        /// It Display the Patient List
        /// </summary>
        /// <param name="patients">List Of Patient</param>
        public static void DisplayAllPatient(List<Patient> patients)
        {
            try
            {
                if (patients.Count == 0)
                {
                    Console.WriteLine("No Data Present.");
                    return;
                }
                else
                {
                    int count = 1;
                    var table = new ConsoleTable("No.", "Id", "Name", "Mobile Number", "Age");
                    foreach (Patient patient in patients)
                    {
                        table.AddRow(count, patient.PatientId, patient.Name, patient.MobileNumber, patient.Age);
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
        /// Display User Specific Query Doctor Details
        /// </summary>
        /// <param name="doctors"></param>
        public static void DisplayUserQueryDoctor(List<Doctor> doctors)
        {
            try
            {
                int choice;
                string Id, name, specialization, availability;

                Doctor doctor;

                bool flag;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Search Doctor By Id");
                    Console.WriteLine("2. Search Doctor By Name");
                    Console.WriteLine("3. Search Doctor By Specialization");
                    Console.WriteLine("4. Search Doctor By Availability");
                    Console.WriteLine("5. Exit");
                    Console.Write("Enter Your Choice: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    ErrorMessage(flag);
                } while (!flag);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.Write("Enter the doctor Id: ");
                        Id = Console.ReadLine();
                        doctor = CliniqueManagementSearch.SearchDoctorById(doctors, Id);
                        if (doctor == null)
                            Console.WriteLine("No Data Present.");
                        else
                        {
                            Console.WriteLine("No.\tId\tName\tSpecialization\tAvailability");
                            Console.WriteLine(1 + "\t" + doctor.DoctorId + "\t" + doctor.Name + "\t" + doctor.Specialization + "\t" + doctor.Availability);

                        }
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.Write("Enter the doctor Name: ");
                        name = Console.ReadLine();
                        doctor = CliniqueManagementSearch.SearchDoctorByName(doctors, name);
                        if (doctor == null)
                            Console.WriteLine("No Data Present.");
                        else
                        {
                            Console.WriteLine("No.\tId\tName\tSpecialization\tAvailability");
                            Console.WriteLine(1 + "\t" + doctor.DoctorId + "\t" + doctor.Name + "\t" + doctor.Specialization + "\t" + doctor.Availability);

                        }
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.Write("Enter the Doctor Specialization: ");
                        specialization = Console.ReadLine();
                        doctor = CliniqueManagementSearch.SearchDoctorBySpecialization(doctors, specialization);
                        if (doctor == null)
                            Console.WriteLine("No Data Present.");
                        else
                        {
                            Console.WriteLine("No.\tId\tName\tSpecialization\tAvailability");
                            Console.WriteLine(1 + "\t" + doctor.DoctorId + "\t" + doctor.Name + "\t" + doctor.Specialization + "\t" + doctor.Availability);
                        }
                        break;

                    case 4:
                        Console.WriteLine();
                        Console.Write("Enter the Doctor Availability: ");
                        availability = Console.ReadLine();
                        doctor = CliniqueManagementSearch.SearchDoctorByAvailability(doctors, availability);
                        if (doctor == null)
                            Console.WriteLine("No Data Present.");
                        else
                        {
                            Console.WriteLine("No.\tId\tName\tSpecialization\tAvailability");
                            Console.WriteLine(1 + "\t" + doctor.DoctorId + "\t" + doctor.Name + "\t" + doctor.Specialization + "\t" + doctor.Availability);
                        }
                        break;

                    case 5:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. !!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// Display User Specific Query Patient Details
        /// </summary>
        /// <param name="patients"></param>
        public static void DisplayUserQueryPatient(List<Patient> patients )
        {
            try
            {
                int choice;
                string Id, name, mobileNumber;

                Patient patient;

                bool flag;
                do
                {
                    Console.WriteLine();
                    Console.WriteLine("1. Search Patient By Id");
                    Console.WriteLine("2. Search Patient By Name");
                    Console.WriteLine("3. Search Patient By Mobile Number");
                    Console.WriteLine("4. Exit");
                    Console.Write("Enter Your Choice: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    ErrorMessage(flag);
                } while (!flag);
                switch (choice)
                {
                    case 1:
                        Console.WriteLine();
                        Console.Write("Enter the Patient Id: ");
                        Id = Console.ReadLine();
                        patient = CliniqueManagementSearch.SearchPatientById(patients, Id);
                        if (patient == null)
                            Console.WriteLine("No Data Present.");
                        else
                        {
                            Console.WriteLine("No.\tId\tName\tMobile Number\tAge");
                            Console.WriteLine(1 + "\t" + patient.PatientId + "\t" + patient.Name + "\t" + patient.MobileNumber + "\t" + patient.Age);

                        }
                        break;

                    case 2:
                        Console.WriteLine();
                        Console.Write("Enter the Patient Name: ");
                        name = Console.ReadLine();
                        patient = CliniqueManagementSearch.SearchPatientByName(patients, name);
                        if (patient == null)
                            Console.WriteLine("No Data Present.");
                        else
                        {
                            Console.WriteLine("No.\tId\tName\tMobile Number\tAge");
                            Console.WriteLine(1 + "\t" + patient.PatientId + "\t" + patient.Name + "\t" + patient.MobileNumber + "\t" + patient.Age);

                        }
                        break;

                    case 3:
                        Console.WriteLine();
                        Console.Write("Enter the Patient Mobile Number: ");
                        mobileNumber = Console.ReadLine();
                        patient = CliniqueManagementSearch.SearchPatientByMobileNumber(patients, mobileNumber);
                        if (patient == null)
                            Console.WriteLine("No Data Present.");
                        else
                        {
                            Console.WriteLine("No.\tId\tName\tMobile Number\tAge");
                            Console.WriteLine(1 + "\t" + patient.PatientId + "\t" + patient.Name + "\t" + patient.MobileNumber + "\t" + patient.Age);

                        }
                        break;

                    case 4:
                        return;

                    default:
                        Console.WriteLine("Invalid Choice. !!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// Update Doctor Details to Json file.
        /// </summary>
        /// <param name="doctors">List Of All Doctors.</param>
        public static void UpdateDoctorToJson(List<Doctor> doctors)
        {
            try
            {
                string filename = CliniqueManagementsProgram.DoctorPath;

                Doctors doctors1 = new Doctors()
                {
                    GetDoctors = doctors
                };

                string updateDoctorData = JsonConvert.SerializeObject(doctors1);

                using StreamWriter streamWriter = new StreamWriter(filename);
                streamWriter.WriteLine(updateDoctorData);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// Update patient Details to Json file.
        /// </summary>
        /// <param name="patients">List Of All Patients.</param>
        public static void UpdatePatientToJson(List<Patient> patients)
        {
            try
            {
                string filename = CliniqueManagementsProgram.PatientPath;

                Patients patients1 = new Patients()
                {
                    GetPatients = patients,
                };

                string updatePatientData = JsonConvert.SerializeObject(patients1);

                using StreamWriter streamWriter = new StreamWriter(filename);
                streamWriter.WriteLine(updatePatientData);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// Update Appointment Details to Json file.
        /// </summary>
        /// <param name="appointments">List Of All Appointment.</param>
        public static void UpdateAppointmentToJson(List<Appointment> appointments)
        {
            try
            {
                string filename = CliniqueManagementsProgram.AppointmentPath;

                Appointments appointments1 = new Appointments()
                {
                    GetAppointments = appointments
                };

                string updateAppointmentData = JsonConvert.SerializeObject(appointments1);

                using StreamWriter streamWriter = new StreamWriter(filename);
                streamWriter.WriteLine(updateAppointmentData);

                Console.WriteLine("Appointment Has been Booked.");
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
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
                    Console.WriteLine("Please Input the Number !!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }


    }
}
