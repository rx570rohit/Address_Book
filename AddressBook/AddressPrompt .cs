using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressBook
{
    class AddressPrompt
    {
        public static String FirstName = "^[A-Z]{1}[A-Za-z]{2,}$";
        public static String LastName = "^[A-Z]{1}[A-Za-z]{2,}$";
        public static String MobNo = "^[0-9]{10}$";
        public static String Emaill = @"^([a-z]+)(\.[a-z0-9_\+\-]+)@([a-z]+)\.([a-z]{2,4})(\.[a-z]{2})?$";
        public static String Cityy = "[A-Za-z]{3,}";
        public static String Zipcode = "[0-9]{6}";
        AddressBook book;

        public AddressPrompt()
        {
            book = new AddressBook();
        }

        static void Main(string[] args)
        {
            string selection = "";
            AddressPrompt prompt = new AddressPrompt();

            prompt.displayMenu();
            while (!selection.ToUpper().Equals("Q"))
            {
                Console.WriteLine("Selection: ");
                selection = Console.ReadLine();
                prompt.performAction(selection);
            }
        }

        void displayMenu()
        {
            Console.WriteLine("Main Menu");
            Console.WriteLine("=========");
            Console.WriteLine("A - Add an Address");
            Console.WriteLine("D - Delete an Address");
            Console.WriteLine("E - Edit an Address");
            Console.WriteLine("L - List All Addresses");
            Console.WriteLine("Q - Quit");
        }

        void performAction(string selection)
        {
            string firstname = "";
            string address = "";
            string lastname = "";
            string city="";
            string state="";
            int zipcode=0;
            string email="";
            long phoneNo=0;

            switch (selection.ToUpper())
            {
                case "A":

                    Console.WriteLine("Enter firstName lastname  address  city  state  zipcode  email  phoneno: ");
                    Console.Write("FirstName : ");  String fname = Console.ReadLine();
                    Console.Write("LasttName : "); String lname = Console.ReadLine();
                    Console.Write("Address : "); address = Console.ReadLine();
                    Console.Write("City Name : "); String City = Console.ReadLine();
                    Console.Write("State Name: "); String State = Console.ReadLine();
                    Console.Write("ZipCode : "); String zip = Console.ReadLine();
                    Console.Write("Email : "); String Email = Console.ReadLine();
                    Console.Write("Phone no : "); String Phone = Console.ReadLine();


                    if (Regex.IsMatch(fname, FirstName))
                    {
                        firstname = fname;
                    }
                    else {
                        Console.WriteLine("Please enter correct first name ");
                        Console.WriteLine();

                    }

                    if (Regex.IsMatch(lname,LastName))
                    {
                        lastname = lname;
                    }
                    else
                    {
                        Console.WriteLine("enter the correct last name ");
                        Console.WriteLine();

                    }
                    
                    if (Regex.IsMatch(City, Cityy))
                    {
                        city = City;
                    }
                    else
                    {
                        Console.WriteLine("City name not Less then 3 char ");
                        Console.WriteLine();

                    }
                    if (Regex.IsMatch(zip ,Zipcode))
                    {
                        zipcode = int.Parse(zip);
                    }
                    else
                    {
                        Console.WriteLine("Zip code must be of 6 char length ");
                        Console.WriteLine();

                    }
                    if (Regex.IsMatch(Email, Emaill))
                    {
                     email = Email;
                    }
                    else
                    {
                        Console.WriteLine("Please Write the correct email");
                        Console.WriteLine();

                    }
                    if (Regex.IsMatch(Phone, MobNo))
                    {
                        phoneNo = long.Parse(Phone);
                    }
                    else
                    {
                        Console.WriteLine("phone no must be of 10 digit  and follows by +91 ");
                        Console.WriteLine();
                        
                    }

                    if ((Regex.IsMatch(fname, FirstName))==false || (Regex.IsMatch(Phone, MobNo))==false|| (Regex.IsMatch(Email, Emaill))==false || (Regex.IsMatch(zip, Zipcode))==false|| (Regex.IsMatch(City, Cityy))==false || (Regex.IsMatch(lname, LastName))==false)
                        {
                        break;
                    }
                    /*
                    address = Console.ReadLine();
                    city = Console.ReadLine();
                    state = Console.ReadLine();
                    zipcode = int.Parse(Console.ReadLine());
                    email = Console.ReadLine();
                    phoneNo = long.Parse(Console.ReadLine());
                    */

                    if (book.add(firstname, lastname, address, city, state, zipcode, email, phoneNo))
                    {
                        Console.WriteLine("Address successfully added!");
                    }
                    else
                    {
                        Console.WriteLine("An address is already on file for {0}.", firstname+" "+lastname);
                    }
                    break;
                case "D":
                    Console.WriteLine("Enter Name to Delete: ");
                    firstname= Console.ReadLine();
                    lastname= Console.ReadLine();
                    
                    if (book.remove(firstname ,lastname))
                    {
                        Console.WriteLine("Address successfully removed");
                    }
                    else
                    {
                        Console.WriteLine("Address for {0} could not be found.", firstname+" "+lastname);
                    }
                    break;
                case "L":
                    if (book.isEmpty())
                    {
                        Console.WriteLine("There are no entries.");
                    }
                    else
                    {
                        Console.WriteLine("Addresses:");
                        book.list((a) => Console.WriteLine("{0} - {1}", a.getName(), a.getAddress()));
                    }
                    break;
                case "E":
                    Console.WriteLine("Enter Name to Edit: ");
                    firstname = Console.ReadLine();
                    lastname = Console.ReadLine();
                   string name = firstname + lastname;
                    Address addr = book.find(name);
                    if (addr == null)
                    {
                        Console.WriteLine("Address for {0} count not be found.", name);
                    }
                    else
                    {
                        Console.WriteLine("Enter new Address: ");
                        addr.setAddress( Console.ReadLine());
                        Console.WriteLine("Address updated for {0}", name);
                    }
                    break;
            }

        }
    }
}