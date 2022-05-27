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

        private string name;
        private string address;
        private string city;
        private string state;
        private int zipcode;
        private string email;
        private long phoneNo;

        public void setName(String name)
        {
            if (name == null)
                throw new Exception("Name cannot be null");
            else
            {
                this.name = name;
            }
        }
        public String getName()
        {

            return this.name;
        }
        public void setAddress(String address)
        {
            if (address == "")
                throw new Exception(" not found");
            else { this.address = address; }

        }
        public String getAddress()
        {
            return (this.address);
        }
        public void setCity(String city)
        {
            if (city == null) { throw new Exception("City name cannot not be null"); }

            else { this.city = city; }
        }
        public String getCity()
        {
            return this.city;
        }
        public void setState(String state)
        {
            if (state == null) { throw new Exception("State cannot be nul"); }
            else { this.state = state; }

        }
        public String getState()
        {
            return (this.state);
        }
        public void setZip(int zip)
        {
            if (zip.ToString().Length < 5)

                throw new Exception(" wrong zipcode ");

            else
            {
                this.zipcode = zip;
            }
        }
        public int getZip()
        {
            return (this.zipcode);
        }
        public void setEmail(String email)
        {
            if (email == null) { throw new Exception("email cannot be null"); }
            else { this.email = email; }

        }
        public String getEmail()
        {
            return (this.email);
        }

        public void setPhoneNo(long ph)
        {
            if (ph.ToString().Length < 10)
                throw new Exception("phone must be of 10 digit");
            else { this.phoneNo = ph; }

        }
        public long getPhoneNo()
        {
            return this.phoneNo;
        }

        public Address(string firstname, string lastName, string address, string city, string state, int zipcode, string email, long phoneNo)
        {

            setName(firstname + lastName);
            setAddress(address);
            setCity(city);
            setState(state);
            setZip(zipcode);
            setEmail(email);
            setPhoneNo(phoneNo);
        }




    }
}