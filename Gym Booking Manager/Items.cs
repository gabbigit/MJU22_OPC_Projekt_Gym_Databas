using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
