using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal abstract class Items
    {
       protected int quantity;
    }
    internal class Equipment : Items
    {
        private string typeOfEquipment { get; set; }
        public Equipment(int quantity)
        {
            this.quantity = quantity;
        }
    }
    internal class Instructor : Items
    {
        private string name { get; set; }
        public Instructor(string name)
        {
            this.quantity = 1;
            this.name = name;
        }
        //added to be able to print instructor name
        public override string ToString()
        {
            return $"{name}";
        }
    }
}
