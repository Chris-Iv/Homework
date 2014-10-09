using System;
using System.Collections.Generic;

namespace Customer
{
    public class Customer : ICloneable, IComparable<Customer>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Id { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public List<Payment> Payments { get; set; }
        public CustomerType Type { get; set; }

        public Customer(string firstName, string middleName, string lastName,
            string id, string address, string phone, string email,
            List<Payment> payments, CustomerType type)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Id = id;
            this.Address = address;
            this.Phone = phone;
            this.Email = email;
            this.Payments = payments;
            this.Type = type;
        }

        public override bool Equals(object obj)
        {
            Customer customer = obj as Customer;

            bool equalNames = Equals(this.FirstName, customer.FirstName) &&
                Equals(this.MiddleName, customer.MiddleName) &&
                Equals(this.LastName, customer.LastName);

            bool equalDetails = Equals(this.Id, customer.Id) &&
                Equals(this.Address, customer.Address) &&
                Equals(this.Phone, customer.Phone) &&
                Equals(this.Email, customer.Email) &&
                Equals(this.Type, customer.Type);

            bool equalPaymentsCount = this.Payments.Count == customer.Payments.Count;

            bool equalPayments = true;
            for (int i = 0; i < this.Payments.Count; i++)
            {
                bool paymentsCheck = Equals(this.Payments[i], customer.Payments[i]);
                if (!paymentsCheck)
                {
                    equalPayments = false;
                }
            }

            if (equalNames && equalDetails && equalPaymentsCount && equalPayments)
            {
                return true;
            }

            return false;
        }

        public static bool operator == (Customer firstCustomer, Customer secondCustomer)
        {
            bool result = Equals(firstCustomer, secondCustomer);
            return result;
        }

        public static bool operator !=(Customer firstCustomer, Customer secondCustomer)
        {
            bool result = !Equals(firstCustomer, secondCustomer);
            return result;
        }

        public object Clone()
        {
            List<Payment> currentPayments = new List<Payment>();
            for (int i = 0; i < this.Payments.Count; i++)
            {
                currentPayments[i] = this.Payments[i];
            }

            return new Customer(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Id,
                this.Address,
                this.Phone,
                this.Email,
                currentPayments,
                this.Type);
        }

        public int CompareTo(Customer other)
        {
            if (this.FirstName == other.FirstName)
            {
                return this.Id.CompareTo(other.Id);
            }

            return this.FirstName.CompareTo(other.FirstName);
        }

        public override int GetHashCode()
        {
            int result = this.FirstName.GetHashCode() ^
                this.MiddleName.GetHashCode() ^
                this.LastName.GetHashCode() ^
                this.Id.GetHashCode() ^
                this.Address.GetHashCode() ^
                this.Phone.GetHashCode() ^
                this.Email.GetHashCode() ^
                this.Payments.GetHashCode() ^
                this.Type.GetHashCode();

            return result;
        }

        public override string ToString()
        {
            string paymentsString = "";
            if (this.Payments.Count != 0)
            {
                foreach (var payment in this.Payments)
                {
                    paymentsString += payment + " ";
                }
            }

            string customerString = String.Format("{0} {1} {2}\nEGN: {3}\nAddress: {4}\nMobile: {5}\nEmail: {6}\nPayments: {7}\nType: {8}",
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Id,
                this.Address,
                this.Phone,
                this.Email,
                paymentsString,
                this.Type);

            return customerString;
        }
    }
}
