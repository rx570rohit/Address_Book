using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class AddressPrompt
    {
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
                   firstname = Console.ReadLine();
                    lastname = Console.ReadLine();
                    address = Console.ReadLine();
                    city = Console.ReadLine();
                    state = Console.ReadLine();
                    zipcode = int.Parse(Console.ReadLine());
                    email = Console.ReadLine();
                    phoneNo = long.Parse(Console.ReadLine());
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
                        book.list((a) => Console.WriteLine("{0} - {1}", a.name, a.address));
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
                        addr.address = Console.ReadLine();
                        Console.WriteLine("Address updated for {0}", name);
                    }
                    break;
            }

        }
    }
}