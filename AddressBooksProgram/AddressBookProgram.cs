/*
 *  Purpose: Program to implement the Address Book.
 * 
 *  @author  Rahul Chaurasia
 *  @version 1.0
 *  @since   21-12-2019
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedProgram.AddressBooksProgram
{
    class AddressBookProgram
    {
        
        /// <summary>
        /// This Method is used to test the AddressBookProgram Class.
        /// </summary>
        public static void AddressBook()
        {
            Console.WriteLine();
            Console.WriteLine("-----------------Address Book Program-----------------");
            Console.WriteLine();

            string addressPath = @"C:\Users\User\source\repos\ObjectOrientedProgram\ObjectOrientedProgram\AddressBooksProgram\AddressBook.json";

            string addressString = File.ReadAllText(addressPath);

            var addressData = JsonConvert.DeserializeObject<AddressBookList>(addressString);

            int choice;
            bool flag = false, inputFlag;

            List<AddressBook> addressBookList; 
            AddressBook addressBook;
            

            if (addressData == null)
                addressBookList = new List<AddressBook>();
            else
                addressBookList = addressData.AddressBook;
            
            do
            {
                do
                {
                    Console.WriteLine("Welcome to Bridgelabz Address Book");
                    Console.WriteLine();
                    Console.WriteLine("1. Create Contact");
                    Console.WriteLine("2. Edit Contact");
                    Console.WriteLine("3. Delete Contact");
                    Console.WriteLine("4. Sort By Name");
                    Console.WriteLine("5. Sort By ZIP");
                    Console.WriteLine("6. Quit.");
                    Console.Write("Enter Your Choice: ");
                    inputFlag = int.TryParse(Console.ReadLine(), out choice);
                    Utility.ErrorMessage(inputFlag);
                } while (!inputFlag);
                switch(choice)
                {
                    case 1:
                        Console.WriteLine();
                        addressBook = Utility.CreateAddressBookData();
                        addressBookList.Add(addressBook);
                        Console.WriteLine("New Contact has been Successfully Created. !!");
                        break;

                    case 2:
                        Console.WriteLine();
                        addressBookList = Utility.EditAddressBookData(addressBookList);
                        Console.WriteLine("The Contact Has Been Successfully Updated. !!");
                        break;

                    case 3:
                        Console.WriteLine();
                        addressBookList = Utility.DeleteAddressBookData(addressBookList);
                        break;

                    case 4:
                        Console.WriteLine("This Program Still not Implemented.");
                        break;

                    case 5:
                        Console.WriteLine("This Program Still not Implemented.");
                        break;

                    case 6:
                        flag = true;
                        break;

                    default:
                        Console.WriteLine("Invalid Choice. !!");
                        break;
                }
            } while (!flag);

            AddressBookList addressBookList1 = new AddressBookList
            {
                AddressBook = addressBookList
            };

            string printAddressBook = JsonConvert.SerializeObject(addressBookList1);

            using (StreamWriter streamWriter = new StreamWriter(addressPath))
                streamWriter.WriteLine(printAddressBook);

            

        }
    }
}
