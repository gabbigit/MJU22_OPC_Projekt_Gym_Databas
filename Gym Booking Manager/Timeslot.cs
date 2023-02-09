using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    
    internal class TimeSlot
    {
        private DateTime start;
        private DateTime end;

        public TimeSlot(DateTime start, DateTime end)
        {
            this.start = start;
            this.end = end;
        }
        override public string ToString()
        {
            return "Time Slot: " + start.ToString() + " - " + end.ToString();
        }
    }
}
