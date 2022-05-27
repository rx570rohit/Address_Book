using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    /*first and last names, address,
city, state, zip, phone number and
email...*/

    internal class AddressBook
    {
        List<Address> addresses;
        
        public AddressBook()
        {
            addresses = new List<Address>();
        }

        public bool add(string firstname, string lastName, string address, string city, string state, int zipcode, string email, long phoneNo)
        {

            Address addr = new Address(firstname, lastName, address, city, state, zipcode, email, phoneNo);
            string name = firstname + lastName;
            Address result = find(name);


            if (result == null)
            {
                addresses.Add(addr);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool remove(string firstname, string lastName)
        {
            string name = firstname + lastName;
            Address addr = find(name);
            if (addr != null)
            {
                addresses.Remove(addr);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void list(Action<Address> action)
        {
            addresses.ForEach(action);
        }

        public bool isEmpty()
        {
            return (addresses.Count == 0);
        }

        public Address find(string name)
        {
            Address addr = addresses.Find((a) => a.getName() == name);
            return addr;
        }

    }
}
