using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_Booking_Manager
{
    internal class GroupActivity
    {
        private string activityID;
        private int participantLimit;
        private List<Customer> participants;
        private TimeSlot timeSlot;
        private Instructor instructor;
        private Space space;
        private Equipment equipment;

        public List<Customer> Participants
        { 
            get => participants;
        }

        public GroupActivity(string activityID, int participantLimit, DateTime start, DateTime end, Instructor instructor, Space space, Equipment equipment)
        {
            this.activityID = activityID;
            this.participantLimit = participantLimit;
            this.timeSlot = timeSlot;
            this.instructor = instructor;
            this.space = space;
            this.equipment = equipment;
            this.participants = new List<Customer>();
        }
        public void SignUp(Customer customer)
        {
            if (participants.Count < participantLimit)
            {
                participants.Add(customer);
            }
            else
            {
                Console.WriteLine("Activity is full");
            }
        }
        //For future use 
        public override string ToString()
        {
            return $"activity: {activityID} with instructor: {instructor}, time: {timeSlot}, space: {space}, participants: {participants}, equipment: {equipment}";
        }
    }
   
}
