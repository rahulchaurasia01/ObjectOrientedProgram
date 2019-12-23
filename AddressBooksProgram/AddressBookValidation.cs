﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ObjectOrientedProgram.AddressBooksProgram
{
    class AddressBookValidation
    {

        /// <summary>
        /// It return true If the validation Matches the pattern.
        /// </summary>
        /// <param name="name">Its a string</param>
        /// <returns></returns>
        public static bool NameValidation(string name)
        {
            string pattern = @"^[a-zA-Z\s]*$";
            return Regex.IsMatch(name, pattern);
        }

        /// <summary>
        /// It return true if the Address Validation matches the pattern.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool AddressValidation(string address)
        {
            string pattern = @"^[a-zA-Z\s]*$"; ;
            return Regex.IsMatch(address, pattern);
        }

        /// <summary>
        /// It return true if the Email Validation Matches the Pattern.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool EmailValidation(string email)
        {
            string pattern = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// It return true if the Mobile Number Validation Matches the Pattern.
        /// </summary>
        /// <param name="mobileNumber"></param>
        /// <returns></returns>
        public static bool MobileNumberValidation(string mobileNumber)
        {
            string pattern = @"^((\+)?(\d{2}[-])?(\d{10}){1})?(\d{11}){0,1}?$";
            return Regex.IsMatch(mobileNumber, pattern);
        }

        /// <summary>
        /// It return true If the Zip Validation Matches the Pattern.
        /// </summary>
        /// <param name="zip"></param>
        /// <returns></returns>
        public static bool ZipValidation(string zip)
        {
            string pattern = @"^[1-9][0-9]{5}$";
            return Regex.IsMatch(zip, pattern);
        }




    }
}