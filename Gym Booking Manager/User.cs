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

        public static User ChooseUserType(string name, string phone, string email, Guid Id, int choice)
        {
            switch (choice)
            {
                case 0:
                    return new Customer(name, phone, email,Id);
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

    internal class Staff : User, ICSVable
    {
        public Staff(string name) : base(name)
        {
            this.perm = 1;
        }
        public new string CSVify()
        {
            return $"{nameof(name)}:{this.name},{nameof(phone)}:{this.phone},{nameof(email)}:{this.email},{nameof(Id)}:{this.Id}";
        }
    }
    
    internal class Admin : User, ICSVable
    {
        public Admin(string name) : base(name)
        {
            this.perm = 2;
        }
        public new string CSVify()
        {
            return $"{nameof(name)}:{this.name},{nameof(phone)}:{this.phone},{nameof(email)}:{this.email},{nameof(Id)}:{this.Id}";
        }
    }

}