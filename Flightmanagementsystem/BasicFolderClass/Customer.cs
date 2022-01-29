using System;

namespace Flightmanagementsystem
{

    public class Customer : IPoco, IUser

    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _userName;
        private string _password;
        private string _address;
        private string _phoneNo;
        private string _creditCardNumber;
        public int Id
        {


            get { return _id; }
            set { _id = value; }

        }
        public string FirstName
        {

            get { return _firstName; }
            set { _firstName = value; }

        }
        public string LastName
        {

            get { return _lastName; }
            set { _lastName = value; }

        }
        public string UserName
        {

            get { return _userName; }
            set { _userName = value; }


        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }


        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string PhoneNo
        {
            get { return _phoneNo; }
            set { _phoneNo = value; }
        }
        public string CreditCardNumber
        {
            get { return _creditCardNumber; }
            set { _creditCardNumber = value; }
        }
        public Customer() { }

        public Customer(string firstName, string lastName, string userName, string password, string address, string phoneNo, string creditCardNumber)
        {
            _firstName = firstName;
            _lastName = lastName;
            _userName = userName;
            _password = password;
            _address = address;
            _phoneNo = phoneNo;
            _creditCardNumber = creditCardNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is Customer c &&
                   Id == c.Id;
        }

        public override string ToString()
        {
            return ($"Customer {Id} ,{FirstName}, {LastName}, {UserName}, {Password}, {Address}, {PhoneNo}, {CreditCardNumber}");
        }

        public override int GetHashCode()
        {
            return + Id.GetHashCode();
        }

        public static bool operator ==(Customer customer, Customer customer1)
        {
            if (customer == null && customer1 == null)
                return true;
            if (customer == null && customer1 != null || customer1 == null && customer != null)
                return false;
            return (customer.Id == customer1.Id);
        }
        public static bool operator !=(Customer customer, Customer customer1)
        {
            return !(customer == customer1);
        }
    }
}

