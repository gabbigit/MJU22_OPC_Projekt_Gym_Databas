using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    
    internal class TimeSlot : IComparable<TimeSlot>
    {
        private DateTime start;
        private DateTime end;

        public TimeSlot(DateTime start)
        {
            this.start = start;
            this.end = start.AddHours(1);
        }
        override public string ToString()
        {
            return "Time Slot: " + start.ToString() + " - " + end.ToString();
        }
        public int CompareTo(TimeSlot? other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;
            // Sort primarily on category.
            if (this.start != other.start) return this.start.CompareTo(other.start);
            // When category is the same, sort on name.
            return this.end.CompareTo(other.end);
        }
    }
}
