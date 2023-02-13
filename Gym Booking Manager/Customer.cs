using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

namespace Gym_Booking_Manager
{
    internal class Customer : User, ICSVable, IComparable<Customer>
    {
        public Customer(string name, string phone, string email, Guid Id) : base(name)
        {
            this.perm = 0;
            this.phone = phone;
            this.email = email;
            this.Id = Id;
        }
        public Customer(string name, string phone, string email) : base(name)
        {
            this.name = name;
            this.phone = phone;
            this.email = email;
        }
        public Customer(Dictionary<string, string> dict) : base(dict[nameof(name)])
        {
            this.name = dict[nameof(name)];
            this.phone = dict[nameof(phone)];
            this.email = dict[nameof(email)];
            this.Id = Guid.Parse(dict[nameof(Id)]);
        }
        public int CompareTo(Customer? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.Id != other.Id) return this.Id.CompareTo(other.Id);
            // When category is the same, sort on name.
            return this.name.CompareTo(other.name);
        }

        public string CSVify()
        {
            return $"{nameof(name)}:{this.name},{nameof(phone)}:{this.phone},{nameof(email)}:{this.email},{nameof(Id)}:{this.Id}";
        }
        public override string ToString()
        {
            return $"{name}, {phone}, {email}, {Id}";
        }
    }
}
