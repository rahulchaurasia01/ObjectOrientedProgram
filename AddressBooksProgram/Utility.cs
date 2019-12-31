using ConsoleTables;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedProgram.AddressBooksProgram
{
    class Utility
    {

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
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }
    
        /// <summary>
        /// It prints the error Message, If the Input value doesnt matches the regex.
        /// </summary>
        /// <param name="flag"></param>
        public static void AddressBookErrorMessage(bool flag, string str)
        {
            try
            {
                if (!flag)
                {
                    Console.WriteLine("Please Input the {0} Properly !!!", str);
                    Console.WriteLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// It Create the New Contact in the Address Book.
        /// </summary>
        /// <returns></returns>
        public static AddressBook CreateAddressBookData()
        {
            try
            {
                string name, mobileNumber, email, address, zip;
                bool flag;

                AddressBook addressBook = new AddressBook();

                do
                {
                    Console.Write("Enter Your Name: ");
                    name = Console.ReadLine();
                    flag = AddressBookValidation.NameValidation(name);
                    AddressBookErrorMessage(flag, "Name");
                } while (!flag);

                do
                {

                    Console.Write("Enter Your Mobile Number: ");
                    mobileNumber = Console.ReadLine();
                    flag = AddressBookValidation.MobileNumberValidation(mobileNumber);
                    AddressBookErrorMessage(flag, "Mobile Number");
                } while (!flag);

                do
                {
                    Console.Write("Enter Your Email-Id: ");
                    email = Console.ReadLine();
                    flag = AddressBookValidation.EmailValidation(email);
                    AddressBookErrorMessage(flag, "Email-Id");
                } while (!flag);

                do
                {
                    Console.Write("Enter Your Address: ");
                    address = Console.ReadLine();
                    flag = AddressBookValidation.AddressValidation(address);
                    AddressBookErrorMessage(flag, "Address");
                } while (!flag);

                do
                {
                    Console.Write("Enter Your Zip: ");
                    zip = Console.ReadLine();
                    flag = AddressBookValidation.ZipValidation(zip);
                    AddressBookErrorMessage(flag, "Zip");
                } while (!flag);

                addressBook.Name = name;
                addressBook.MobileNumber = mobileNumber;
                addressBook.Email = email;
                addressBook.Address = address;
                addressBook.Zip = zip;

                return addressBook;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It Edit the contact present in the Address Book
        /// </summary>
        /// <param name="addressBooks">It the list of all Address Data</param>
        /// <returns>It return all the Address Book Data</returns>
        public static List<AddressBook> EditAddressBookData(List<AddressBook> addressBooks)
        {
            try
            {
                if (addressBooks.Count == 0)
                {
                    Console.WriteLine("Address Book is Empty");
                    return null;
                }

                DisplayAddressBookData(addressBooks);

                int choice, count;
                bool inputFlag;
                string name = null, mobileNumber = null, email = null, address = null, zip = null;
                bool flag;
                do
                {
                    Console.WriteLine();
                    Console.Write("Please Choose which Contact you want to Edit: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (choice <= 0 || choice > addressBooks.Count)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice");
                        Console.WriteLine();
                        DisplayAddressBookData(addressBooks);
                        flag = false;
                    }
                } while (!flag);

                count = 1;

                foreach (AddressBook addressBook in addressBooks)
                {
                    if (count == choice)
                    {
                        name = addressBook.Name;
                        mobileNumber = addressBook.MobileNumber;
                        email = addressBook.Email;
                        address = addressBook.Address;
                        zip = addressBook.Zip;
                        break;
                    }
                    count++;
                }
                flag = false;
                count--;
                do
                {
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Details for the Selected Address are: ");
                        Console.WriteLine("1. Name: {0}", name);
                        Console.WriteLine("2. Mobile Number: {0}", mobileNumber);
                        Console.WriteLine("3. Email: {0}", email);
                        Console.WriteLine("4. Address: {0}", address);
                        Console.WriteLine("5. Zip: {0}", zip);
                        Console.WriteLine("6. Exit");
                        Console.Write("Enter Your Choice: ");
                        inputFlag = int.TryParse(Console.ReadLine(), out choice);
                        ErrorMessage(inputFlag);
                    } while (!inputFlag);
                    Console.WriteLine();
                    string tempData;
                    switch (choice)
                    {
                        case 1:
                            do
                            {
                                Console.Write("Enter Your Name you want to update: ");
                                tempData = Console.ReadLine();
                                inputFlag = AddressBookValidation.NameValidation(tempData);
                                AddressBookErrorMessage(inputFlag, "Name");
                            } while (!inputFlag);
                            if (ConfirmChange())
                            {
                                name = tempData;
                                addressBooks[count].Name = name;

                            }
                            else
                                addressBooks[count].Name = name;

                            Console.WriteLine("Your Name Has Been Successfully Updated. !!");
                            break;

                        case 2:
                            do
                            {
                                Console.Write("Enter Your Mobile Number you want to update: ");
                                tempData = Console.ReadLine();
                                inputFlag = AddressBookValidation.MobileNumberValidation(tempData);
                                AddressBookErrorMessage(inputFlag, "Mobile Number");
                            } while (!inputFlag);
                            if (ConfirmChange())
                            {
                                mobileNumber = tempData;
                                addressBooks[count].MobileNumber = mobileNumber;
                            }
                            else
                                addressBooks[count].MobileNumber = mobileNumber;

                            Console.WriteLine("Your Mobile Number Has Been Successfully Updated. !!");
                            break;

                        case 3:
                            do
                            {
                                Console.Write("Enter Your Email-Id you want to update: ");
                                tempData = Console.ReadLine();
                                inputFlag = AddressBookValidation.EmailValidation(tempData);
                                AddressBookErrorMessage(inputFlag, "Email-Id");
                            } while (!inputFlag);
                            if (ConfirmChange())
                            {
                                email = tempData;
                                addressBooks[count].Email = email;
                            }
                            else
                                addressBooks[count].Email = email;

                            Console.WriteLine("Your Email-Id Has Been Successfully Updated. !!");
                            break;

                        case 4:
                            do
                            {
                                Console.Write("Enter Your Address you want to update: ");
                                tempData = Console.ReadLine();
                                inputFlag = AddressBookValidation.AddressValidation(tempData);
                                AddressBookErrorMessage(inputFlag, "Address");
                            } while (!inputFlag);
                            if (ConfirmChange())
                            {
                                address = tempData;
                                addressBooks[count].Address = address;
                            }
                            else
                                addressBooks[count].Address = address;

                            Console.WriteLine("Your Address Has Been Successfully Updated. !!");
                            break;

                        case 5:
                            do
                            {
                                Console.Write("Enter Your Zip you want to update: ");
                                tempData = Console.ReadLine();
                                inputFlag = AddressBookValidation.ZipValidation(tempData);
                                AddressBookErrorMessage(inputFlag, "Zip");
                            } while (!inputFlag);
                            if (ConfirmChange())
                            {
                                zip = tempData;
                                addressBooks[count].Zip = zip;
                            }
                            else
                                addressBooks[count].Zip = zip;

                            Console.WriteLine("Your Zip Has Been Successfully Updated. !!");
                            break;

                        case 6:
                            flag = true;
                            break;

                        default:
                            Console.WriteLine("Invalid Choice. !!!");
                            break;
                    }

                } while (!flag);

                return addressBooks;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It delete the specific address book data.
        /// </summary>
        /// <param name="addressBooks"></param>
        /// <returns></returns>
        public static List<AddressBook> DeleteAddressBookData(List<AddressBook> addressBooks)
        {
            try
            {
                if (addressBooks.Count == 0)
                {
                    Console.WriteLine("No Address Data to Delete. !!!");
                    return null;
                }

                DisplayAddressBookData(addressBooks);

                int choice;
                bool flag;
                do
                {
                    Console.WriteLine();
                    Console.Write("Please Choose which Contact you want to Delete: ");
                    flag = int.TryParse(Console.ReadLine(), out choice);
                    if (choice <= 0 || choice > addressBooks.Count)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Invalid Choice");
                        Console.WriteLine();
                        DisplayAddressBookData(addressBooks);
                        flag = false;
                    }
                } while (!flag);

                Console.Write("Are You Sure, Do you want to Delete this Address Data: ");
                if (Console.ReadLine().ToLower()[0] == 'y')
                {
                    addressBooks.RemoveAt(choice - 1);
                    Console.WriteLine("This Address Data has been Successfully Deleted. !!");
                    return addressBooks;
                }
                else
                    return addressBooks;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return null;
            }
        }

        /// <summary>
        /// It Sort the Address Book by its Name
        /// </summary>
        /// <param name="addressBooks"></param>
        public static void SortByNameAddressBookData(List<AddressBook> addressBooks)
        {
            try
            {
                List<AddressBook> tempAddress = addressBooks;
                tempAddress.Sort((addressName1, addressName2) => addressName1.Name.CompareTo(addressName2.Name));
                DisplayAddressBookData(tempAddress);
                Console.WriteLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// It Sort the Address Book by its Zip Code
        /// </summary>
        /// <param name="addressBooks"></param>
        public static void SortByZipAddressBookData(List<AddressBook> addressBooks)
        {
            try
            {
                List<AddressBook> tempAddress = addressBooks;
                tempAddress.Sort((addressName1, addressName2) => addressName1.Zip.CompareTo(addressName2.Zip));
                DisplayAddressBookData(tempAddress);
                Console.WriteLine();
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// It Save the Data in jSon file.
        /// </summary>
        /// <param name="addressBooks"></param>
        /// <param name="addressPath"></param>
        public static void SaveAddressBookInJson(List<AddressBook> addressBooks, string addressPath)
        {
            try
            {
                AddressBookList addressBookList1 = new AddressBookList
                {
                    AddressBook = addressBooks
                };

                string printAddressBook = JsonConvert.SerializeObject(addressBookList1);

                using (StreamWriter streamWriter = new StreamWriter(addressPath))
                    streamWriter.WriteLine(printAddressBook);
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
            }
        }

        /// <summary>
        /// It Display All the Address Book Data
        /// </summary>
        /// <param name="addressBooks"></param>
        public static void DisplayAddressBookData(List<AddressBook> addressBooks)
        {
            try
            {
                if (addressBooks.Count == 0)
                    Console.WriteLine("Address Book is Empty");
                else
                {
                    int count = 1;

                    var table = new ConsoleTable("No.", "Name", "Mobile Number", "Email-Id", "Zip", "Address");
                    foreach (AddressBook addressBook in addressBooks)
                    {
                        table.AddRow(count, addressBook.Name, addressBook.MobileNumber, addressBook.Email, addressBook.Zip, addressBook.Address);
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
        /// Confirm with the user, whether they want to update their Address book or not.
        /// </summary>
        /// <returns></returns>
        public static bool ConfirmChange()
        {
            try
            {
                Console.Write("Are You Sure you want to update ur Address Data [y/n]: ");
                if (Console.ReadLine().ToLower()[0] == 'y')
                    return true;
                else
                    return false;
            }
            catch(Exception e)
            {
                Console.WriteLine("Message: {0}", e.Message);
                return false;
            }
        }
    
    }
}
