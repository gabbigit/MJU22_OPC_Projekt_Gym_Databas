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
        public DateTime start { get; set; }
        public DateTime end { get; set; }
        private Category category;
        private int quantity;

        public Reservation(Category category, IReservingEntity owner, DateTime start, DateTime end)
        {
            this.owner = owner;
            this.start = start;
            this.end = end;
            this.category = category;
        }
        public Reservation(Category category, int quantity ,IReservingEntity owner, DateTime start, DateTime end)
        {
            this.owner = owner;
            this.start = start;
            this.end = end;
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
            return $"{category} {quantity} {owner}: {start} - {end}";
        }

    }
}