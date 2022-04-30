using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class Address
    /*first and last names, address,
city, state, zip, phone number and
email...*/
    {
        public string name;
        public string address;
        public string city;
        public string state;
        public int zipcode;
        public string email;
        public long phoneNo;

        public Address(string firstname, string lastName, string address, string city, string state, int zipcode, string email, long phoneNo)
        {
            this.name = firstname+ lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zipcode = zipcode;
            this.email = email;
            this.phoneNo = phoneNo;
        }
    }
}