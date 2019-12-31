using ObjectOrientedProgram.CliniqueManagementProgram.GetterSetter;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedProgram.CliniqueManagementProgram.Core
{
    class CliniqueManagementSearch
    {

        /// <summary>
        /// It search the Doctors by it's Name.
        /// </summary>
        /// <param name="doctor">List Of Doctor</param>
        /// <param name="Name">Doctor Name</param>
        /// <returns>If the Doctor Name is Present, then It return Doctor Object or else null</returns>
        public static Doctor SearchDoctorByName(List<Doctor> doctors, string Name)
        {
            try
            {
                Doctor doctor = doctors.Find(x => x.Name.Equals(Name));

                return doctor;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It search the Doctors by it's Id.
        /// </summary>
        /// <param name="doctor">List Of Doctor</param>
        /// <param name="Id">Doctor Id</param>
        /// <returns>If the Doctor Id is Present, then It return Doctor Object or else null</returns>
        public static Doctor SearchDoctorById(List<Doctor> doctors, string Id)
        {
            try
            {
                Doctor doctor = doctors.Find(x => x.DoctorId.Equals(Id));

                return doctor;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It search the Doctors by it's Specialization.
        /// </summary>
        /// <param name="doctor">List Of Doctor</param>
        /// <param name="specialization">Doctor Specialization</param>
        /// <returns>If the Doctor Specialization is Present, then It return Doctor Object or else null</returns>
        public static Doctor SearchDoctorBySpecialization(List<Doctor> doctors, string specialization)
        {
            try
            {
                Doctor doctor = doctors.Find(x => x.Specialization.Equals(specialization));

                return doctor;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It search the Doctors by it's Availability.
        /// </summary>
        /// <param name="doctor">List Of Doctor</param>
        /// <param name="availability">Doctor Availability</param>
        /// <returns>If the Doctor Availability is Present, then It return Doctor Object or else null</returns>
        public static Doctor SearchDoctorByAvailability(List<Doctor> doctors, string availability)
        {
            try
            {
                Doctor doctor = doctors.Find(x => x.Availability.Equals(availability));

                return doctor;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It search the Patient by it's Name.
        /// </summary>
        /// <param name="patients">List Of patient</param>
        /// <param name="Name">Patient Name</param>
        /// <returns>If the Patient Name is Present, then It return Patient Object or else null</returns>
        public static Patient SearchPatientByName(List<Patient> patients, string Name)
        {
            try
            {
                Patient patient = patients.Find(x => x.Name.Equals(Name));

                return patient;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It search the Patient by it's Mobile Number.
        /// </summary>
        /// <param name="patients">List Of patient</param>
        /// <param name="mobileNumber">Patient Mobile Number</param>
        /// <returns>If the Patient Mobile Number is Present, then It return Patient Object or else null</returns>
        public static Patient SearchPatientByMobileNumber(List<Patient> patients, string mobileNumber)
        {
            try
            {
                Patient patient = patients.Find(x => x.MobileNumber.Equals(mobileNumber));

                return patient;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It search the Patient by it's Id.
        /// </summary>
        /// <param name="patients">List Of patient</param>
        /// <param name="Id">Patient Id</param>
        /// <returns>If the Patient Id is Present, then It return Patient Object or else null</returns>
        public static Patient SearchPatientById(List<Patient> patients, string Id)
        {
            try
            {
                Patient patient = patients.Find(x => x.PatientId.Equals(Id));

                return patient;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

    }
}
