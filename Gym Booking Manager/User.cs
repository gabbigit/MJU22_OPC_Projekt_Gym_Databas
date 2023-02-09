using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal abstract class User
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
            this.Id = Guid.NewGuid();
        }

        public static User ChooseUserType(string name, int choice)
        {
            switch (choice)
            {
                case 0:
                    return new Customer(name);
                case 1:
                    return new Staff(name);
                case 2:
                    return new Admin(name);
                default:
                    throw new ArgumentException("Invalid choice");
            }
        }
        public virtual int GetPerm()
        {
            return perm;
        }
    }
    internal class Customer : User, ICSVable
    {
        public Customer(string name) : base(name)
        {
            this.perm = 0;
        }
        public string CSVify()
        {
            return $"{this.name},{this.phone},{this.email},{this.perm},{this.Id}";
        }
    }

    internal class Staff : User, ICSVable
    {
        public Staff(string name) : base(name)
        {
            this.perm = 1;
        }
        public string CSVify()
        {
            return $"{this.name},{this.phone},{this.email},{this.perm},{this.Id}";
        }
    }

    internal class Admin : User, ICSVable
    {
        public Admin(string name) : base(name)
        {
            this.perm = 2;
        }
        public string CSVify()
        {
            return $"{this.name},{this.phone},{this.email},{this.perm},{this.Id}";
        }
    }

}