using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class Reservation
    {
        private readonly IReservingEntity owner;
        public TimeSlot timeSlot { get; set; }
        private Category category;
        private int quantity;

        public Reservation(Category category, IReservingEntity owner, TimeSlot time)
        {
            this.owner = owner;
            this.timeSlot = time;
            this.category = category;
        }
        public Reservation(Category category, int quantity ,IReservingEntity owner, TimeSlot time)
        {
            this.owner = owner;
            this.timeSlot = time;
            this.category = category;
            this.quantity = quantity;
        }
        public enum Category
        {
            Machines,
            Gym,
            Bench,
            Dumbbells,
            Treadmill,
            Rackets,
            PT,
            Coach
        }

        public override string ToString()
        {
            return $"==============================\nCateory:{category}\nreservation for:{owner}\n{timeSlot}\n==============================\n";
        }
    }
}