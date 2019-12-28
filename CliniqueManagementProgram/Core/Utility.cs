/*
 *  Purpose: The Utility Class is used to store the logic of the Clinique Management Program.
 *  
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   28-12-2019
 * 
 */

using Newtonsoft.Json;
using ObjectOrientedProgram.CliniqueManagementProgram.GetterSetter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

        /// <summary>
        /// It Read the Json File Of Patient.
        /// </summary>
        /// <returns>It Return the List of Patient who have Visited the Hospital</returns>
        public static List<Patient> ReadPatientJsonFile()
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

        /// <summary>
        /// Update Doctor Details to Json file.
        /// </summary>
        /// <param name="doctors">List Of All Doctors.</param>
        public static void UpdateDoctorToJson(Doctors doctors)
        {
            string filename = CliniqueManagementsProgram.DoctorPath;

            string updateDoctorData = JsonConvert.SerializeObject(doctors);

            using (StreamWriter streamWriter = new StreamWriter(filename))
                streamWriter.WriteLine(updateDoctorData);

            Console.WriteLine("Doctor Details Has Been Successfully Updated to Json.");
        }

        /// <summary>
        /// Update patient Details to Json file.
        /// </summary>
        /// <param name="patients">List Of All Patients.</param>
        public static void UpdatePatientToJson(Patients patients)
        {
            string filename = CliniqueManagementsProgram.DoctorPath;

            string updatePatientData = JsonConvert.SerializeObject(patients);

            using (StreamWriter streamWriter = new StreamWriter(filename))
                streamWriter.WriteLine(updatePatientData);

            Console.WriteLine("Patient Details Has Been Successfully Updated to Json.");
        }


        /// <summary>
        /// If the Conversion from string to int is not possible
        /// then it prints the error message.
        /// </summary>
        /// <param name="flag"></param>
        public static void ErrorMessage(bool flag)
        {
            if (!flag)
                Console.WriteLine("Please Input the Number !!!");
        }


    }
}
