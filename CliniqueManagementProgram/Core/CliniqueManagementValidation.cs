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
            try
            {
                string pattern = @"^[a-zA-Z\s]*$";
                return Regex.IsMatch(name, pattern);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// It Validate the Doctors Id.
        /// </summary>
        /// <param name="id">Doctor ID</param>
        /// <returns>It return true if the Doctor id matches the Pattern</returns>
        public static bool DoctorIdValidation(string id)
        {
            try
            {
                string pattern = @"^[0-9]{6}";
                return Regex.IsMatch(id, pattern);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// It Validate the Doctors Specialization
        /// </summary>
        /// <param name="name">Doctor Specialization</param>
        /// <returns>It return true if the doctor Specialization Matches the Pattern.</returns>
        public static bool DoctorSpecializationValidation(string specializaion)
        {
            try
            {
                string pattern = @"^[a-zA-Z\s]*$";
                return Regex.IsMatch(specializaion, pattern);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// It Validate the Patients Name
        /// </summary>
        /// <param name="name">Patient Name</param>
        /// <returns>It return true if the Patients name Matches the Pattern.</returns>
        public static bool PatientNameValidation(string name)
        {
            try
            {
                string pattern = @"^[a-zA-Z\s]*$";
                return Regex.IsMatch(name, pattern);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// It Validate the Patient Id.
        /// </summary>
        /// <param name="id">Patient ID</param>
        /// <returns>It return true if the Patient id matches the Pattern</returns>
        public static bool PatientIdValidation(string id)
        {
            try
            {
                string pattern = @"^[0-9]{6}";
                return Regex.IsMatch(id, pattern);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// It Validate the Patient Mobile Number.
        /// </summary>
        /// <param name="mobileNumber">Patient Mobile Number</param>
        /// <returns>It return true if the Patient Mobile Number matches the Pattern.</returns>
        public static bool PatientMobileNumber(string mobileNumber)
        {
            try
            {
                string pattern = @"^((\+)?(\d{2}[-])?(\d{10}){1})?(\d{11}){0,1}?$";
                return Regex.IsMatch(mobileNumber, pattern);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// It Validate the Patient Age.
        /// </summary>
        /// <param name="age">Patient Age</param>
        /// <returns>It return true if Patient Age Matches the Validation</returns>
        public static bool PatientAgeValidation(string age)
        {
            try
            {
                if (Convert.ToInt32(age) <= 0 || Convert.ToInt32(age) > 200)
                    return false;
                else
                    return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }

        /// <summary>
        /// It Validate the Appointment for the patient.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool PatientAppointmentValidation(string date)
        {
            try
            {
                string pattern = @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
                return Regex.IsMatch(date, pattern);
            }
            catch (Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }


    }
}
