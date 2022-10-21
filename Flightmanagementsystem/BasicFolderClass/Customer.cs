using Flightmanagementsystem.DAOClass;
using System;

namespace Flightmanagementsystem.BasicFolderClass
{

    public class Customer :ICustomerDAO,IUser

    {
        public long _Id { get; set; }
        public string _FirstName { get; set; }
        public string _LastName { get; set; }
        public string _Address { get; set; }
        public string _PhoneNum { get; set; }
        public string _CreditCardNum { get; set; }
        public long _UserId { get; set; }

        public Customer() { }

        public Customer(long id, string firstName, string lastName, string address, string phoneNum, string creditCardNum, long userId)
        {
            _Id = id;
            _FirstName = firstName;
            _LastName = lastName;
            _Address = address;
            _PhoneNum = phoneNum;
            _CreditCardNum = creditCardNum;
            _UserId = userId;
        }

        public override bool Equals(object obj)
        {
            return obj is Customer c &&
                   _Id == c._Id;
        }

        public override string ToString()
        {
            return $"Customer {_Id} ,{_FirstName}, {_LastName}, {_Address}, {_PhoneNum}, {_CreditCardNum}";
        }

        public override int GetHashCode()
        {
            return +_Id.GetHashCode();
        }

        public static bool operator ==(Customer customer, Customer customer1)
        {
            if (customer == null && customer1 == null)
                return true;
            if (customer == null && customer1 != null || customer1 == null && customer != null)
                return false;
            return customer._Id == customer1._Id;
        }
        public static bool operator !=(Customer customer, Customer customer1)
        {
            return !(customer == customer1);
        }
    }
}

