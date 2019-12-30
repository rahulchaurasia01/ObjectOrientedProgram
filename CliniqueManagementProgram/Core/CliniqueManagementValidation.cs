using System;
using System.Text.RegularExpressions;

namespace ObjectOrientedProgram.CliniqueManagementProgram.Core
{
    class CliniqueManagementValidation
    {

        /// <summary>
        /// It Validate the Doctors Name
        /// </summary>
        /// <param name="name">Doctor Name</param>
        /// <returns>It return true if the doctor name Matches the Pattern.</returns>
        public static bool DoctorNameValidation(string name)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            return Regex.IsMatch(name, pattern);
        }

        /// <summary>
        /// It Validate the Doctors Id.
        /// </summary>
        /// <param name="id">Doctor ID</param>
        /// <returns>It return true if the Doctor id matches the Pattern</returns>
        public static bool DoctorIdValidation(string id)
        {
            string pattern = @"^[0-9]{6}";
            return Regex.IsMatch(id, pattern);
        }

        /// <summary>
        /// It Validate the Doctors Specialization
        /// </summary>
        /// <param name="name">Doctor Specialization</param>
        /// <returns>It return true if the doctor Specialization Matches the Pattern.</returns>
        public static bool DoctorSpecializationValidation(string specializaion)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            return Regex.IsMatch(specializaion, pattern);
        }

        /// <summary>
        /// It Validate the Patients Name
        /// </summary>
        /// <param name="name">Patient Name</param>
        /// <returns>It return true if the Patients name Matches the Pattern.</returns>
        public static bool PatientNameValidation(string name)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            return Regex.IsMatch(name, pattern);
        }

        /// <summary>
        /// It Validate the Patient Id.
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns>It return true if the Patient id matches the Pattern</returns>
        public static bool PatientIdValidation(string id)
        {
            string pattern = @"^[0-9]{6}";
            return Regex.IsMatch(id, pattern);
        }

        /// <summary>
        /// It Validate the Patient Mobile Number.
        /// </summary>
        /// <param name="mobileNumber">Patient Mobile Number</param>
        /// <returns>It return true if the Patient Mobile Number matches the Pattern.</returns>
        public static bool PatientMobileNumber(string mobileNumber)
        {
            string pattern = @"^((\+)?(\d{2}[-])?(\d{10}){1})?(\d{11}){0,1}?$";
            return Regex.IsMatch(mobileNumber, pattern);
        }

        /// <summary>
        /// It Validate the Patient Age.
        /// </summary>
        /// <param name="age">Patient Age</param>
        /// <returns>It return true if Patient Age Matches the Validation</returns>
        public static bool PatientAgeValidation(string age)
        {
            if (Convert.ToInt32(age) <= 0 || Convert.ToInt32(age) > 200)
                return false;
            else
                return true;
        }


    }
}
