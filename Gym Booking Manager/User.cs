using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static Gym_Booking_Manager.Space;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal abstract class User : ICSVable
    {
        public string name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        protected int perm;
        public Guid Id { get; set; }

        protected User(string name)
        {
            this.name = name;
            this.phone = "0";
            this.email = "test@test";
            this.perm = 0;
            this.Id = new Guid();
        }
        public string CSVify()
        {
            throw new NotImplementedException();
        }

        public static User Create()
        {
            Console.WriteLine("Enter your name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your phone number: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter your email: ");
            string email = Console.ReadLine();
            Guid id = Guid.NewGuid();
            Console.WriteLine("Enter your choice (0 for Customer, 1 for Staff, 2 for Admin, 3 for Service): ");
            int choice = int.Parse(Console.ReadLine());
            //Console.WriteLine(userDB.Read<Customer>("Id", "00e19739-d644-4f05-a042-fec4a9ca946a"));


            return ChooseUserType(name, phone, email, id, choice);
        }
        public static void Remove()
        {
            throw new NotImplementedException();
        }

        public static User ChooseUserType(string name, string phone, string email, Guid Id, int choice)
        {
            switch (choice)
            {
                case 0:
                    return new Customer(name, phone, email,Id);
                case 1:
                    return new Staff(name, phone, email, Id);
                case 2:
                    return new Admin(name, phone, email, Id);
                case 3:
                    return new Service(name, phone, email, Id);
                default:
                    throw new ArgumentException("Invalid choice");
            }
        }
        public virtual int GetPerm()
        {
            return perm;
        }
    }

    internal class Staff : User, ICSVable, IComparable<Staff>
    {
        public Staff(string name, string phone, string email, Guid Id) : base(name)
        {
            this.perm = 1;
            this.phone = phone;
            this.email = email;
            this.Id = Id;
        }
        public Staff(Dictionary<string, string> dict) : base(dict[nameof(name)])
        {
            this.name = dict[nameof(name)];
            this.phone = dict[nameof(phone)];
            this.email = dict[nameof(email)];
            this.Id = Guid.Parse(dict[nameof(Id)]);
        }
        public new string CSVify()
        {
            return $"{nameof(name)}:{this.name},{nameof(phone)}:{this.phone},{nameof(email)}:{this.email},{nameof(Id)}:{this.Id}";
        }
        public override string ToString()
        {
            return $"{name}, {phone}, {email}, {Id}";
        }
        public int CompareTo(Staff? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.Id != other.Id) return this.Id.CompareTo(other.Id);
            // When category is the same, sort on name.
            return this.name.CompareTo(other.name);
        }
    }
    
    internal class Admin : User, ICSVable, IComparable<Admin>
    {
        public Admin(string name, string phone, string email, Guid Id) : base(name)
        {
            this.perm = 2;
            this.phone = phone;
            this.email = email;
            this.Id = Id;
        }
        public Admin(Dictionary<string, string> dict) : base(dict[nameof(name)])
        {
            this.name = dict[nameof(name)];
            this.phone = dict[nameof(phone)];
            this.email = dict[nameof(email)];
            this.Id = Guid.Parse(dict[nameof(Id)]);
        }
        public string CSVify()
        {
            return $"{nameof(name)}:{this.name},{nameof(phone)}:{this.phone},{nameof(email)}:{this.email},{nameof(Id)}:{this.Id}";
        }
        public override string ToString()
        {
            return $"{name}, {phone}, {email}, {Id}";
        }
        public int CompareTo(Admin? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.Id != other.Id) return this.Id.CompareTo(other.Id);
            // When category is the same, sort on name.
            return this.name.CompareTo(other.name);
        }
    }

    internal class Service : User, ICSVable, IComparable<Service>
    {
        public Service(string name, string phone, string email, Guid Id) : base(name)
        {
            this.perm = 2;
            this.phone = phone;
            this.email = email;
            this.Id = Id;
        }
        public Service(Dictionary<string, string> dict) : base(dict[nameof(name)])
        {
            this.name = dict[nameof(name)];
            this.phone = dict[nameof(phone)];
            this.email = dict[nameof(email)];
            this.Id = Guid.Parse(dict[nameof(Id)]);
        }
        public string CSVify()
        {
            return $"{nameof(name)}:{this.name},{nameof(phone)}:{this.phone},{nameof(email)}:{this.email},{nameof(Id)}:{this.Id}";
        }
        public override string ToString()
        {
            return $"{name}, {phone}, {email}, {Id}";
        }
        public int CompareTo(Service? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.Id != other.Id) return this.Id.CompareTo(other.Id);
            // When category is the same, sort on name.
            return this.name.CompareTo(other.name);
        }
    }

    internal class Customer : User, ICSVable, IComparable<Customer>, IReservingEntity
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
        public void PrintAllInfo()
        {
            Console.WriteLine($"Name: {name}, Phone: {phone}, Email: {email}, Id: {Id}");
        }
        public override string ToString()
        {
            return $"{name}, {Id}";
        }
    }

}