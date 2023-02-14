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

        public Instructor Instructor
        {
            get => instructor;
        }

        public List<Customer> Participants
        { 
            get => participants;
        }

        public GroupActivity(string activityID, int participantLimit, DateTime start, DateTime end, Instructor instructor, Space space, Equipment equipment)
        {
            this.activityID = activityID;
            this.participantLimit = participantLimit;
            this.timeSlot = new TimeSlot(start, end);
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
        public void SignOut(Customer customer)
        {
            participants.Remove(customer);
        }
        public string PartisipantsToString()
        {
            string partisipants = "";
            foreach (Customer customer in participants)
            {
                partisipants += customer.name;
            }
            return partisipants;
        }
        public string equipmentToString()
        {
            return equipment.Name;
        }
        //For future use 
        public override string ToString()
        {
            return $"activity: {activityID} with instructor: {Instructor.Name}\n{timeSlot}\nspace: {space}\nparticipants: {PartisipantsToString()}\n equipment: {equipmentToString()}";
        }
    }
   
}
