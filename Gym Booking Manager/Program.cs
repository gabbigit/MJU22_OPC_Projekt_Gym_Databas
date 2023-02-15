using Gym_Booking_Manager;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

#if DEBUG
[assembly: InternalsVisibleTo("Tests")]
#endif
namespace Gym_Booking_Manager
{
    internal class Program
    {

        static void Main(string[] args)
        {
            /*
                        Customer ruben = new Customer("Ruben");
                        Customer david = new Customer("David");
                        Customer adam = new Customer("Adam");
                        TimeSlot timeSlot = new TimeSlot(new DateTime(2023, 10, 10, 20, 30, 00), new DateTime(2023, 10, 10, 21, 00, 00));
                        Console.WriteLine(timeSlot);
                        Instructor instructor = new Instructor("Tim");
                        Space hall = new Space(0, "Hall");
                        Equipment treadmill = new Equipment(1);
                        GroupActivity activity1 = new GroupActivity("A1", 2, timeSlot, instructor, hall, treadmill);
                        activity1.SignUp(ruben);
                        activity1.SignUp(david);
                        activity1.SignUp(adam);
                        foreach(Customer c in activity1.Participants)
                        {
                            Console.WriteLine(c.name);
                        }
            */
            GymDatabaseContext DB = new GymDatabaseContext();
            Customer ruben = new Customer("Ruben", "011-131313", "ruben@test.se", Guid.NewGuid());
            Customer david = new Customer("David", "011-131313", "asd", Guid.NewGuid());
            //userDB.Create<Customer>(ruben);
            //userDB.Create<Customer>(david);
            //userDB.Create<Customer>(ruben);
            DateTime t1 = new DateTime(year: 2023, month: 10, day: 10, hour: 12, minute: 00, second: 00);
            DateTime t2 = new DateTime(year: 2023, month: 10, day: 10, hour: 13, minute: 00, second: 00);
            DateTime t3 = new DateTime(year: 2023, month: 10, day: 10, hour: 14, minute: 00, second: 00);
            DateTime t4 = new DateTime(year: 2023, month: 10, day: 10, hour: 15, minute: 00, second: 00);
            TimeSlot time = new TimeSlot(t1);
            TimeSlot time2 = new TimeSlot(t2);
            Space space = new Space(Space.Category.Hall, "Hall");
            Space space2 = new Space(Space.Category.Studio, "Studio 2");
            Equipment treadmill = new Equipment(Equipment.Category.Gym, "Treadmill", 10, true);
            Equipment gym = new Equipment(Equipment.Category.Gym, "Gym", 10, true);
            DB.Create<Equipment>(gym);
            gym.MakeReservation(Reservation.Category.Gym, ruben, time);
            //gym.ViewTimeTable();
            DB.Create<Equipment>(treadmill);
            treadmill.MakeReservation(0,ruben, time);
            //treadmill.ViewTimeTable();
            Instructor instructor = new Instructor(Instructor.Category.PT, "Tom");
            DB.Create<Instructor>(instructor);
            instructor.MakeReservation(Reservation.Category.PT, ruben, time);
            //instructor.ViewTimeTable();
            GroupActivity groupActivity = new GroupActivity("Activity 1", 2, time2, instructor, space, treadmill);
            GroupSchedule groupSchedule = new GroupSchedule(groupActivity);
            GroupActivity groupActivity2 = new GroupActivity("Activity 2", 3, time, instructor, space2, gym);
            groupSchedule.AddActivity(groupActivity2);
            groupActivity2.SignUp(ruben);
            groupActivity.SignUp(ruben);
            groupActivity.SignUp(david);
            groupSchedule.ViewSchedule();

            foreach (Equipment equipment in DB.Read<Equipment>())
            {
                Console.WriteLine(equipment);
                Console.WriteLine(equipment.Quantity);
            }
            Console.WriteLine(treadmill.Quantity);
            /*
            foreach (Equipment e in DB.Read<Equipment>())
            {
                Console.WriteLine(e);
            }
            foreach (Instructor i in DB.Read<Instructor>())
            {
                Console.WriteLine(i);
            }
            foreach (Space s in DB.Read<Space>())
            {
                Console.WriteLine(s);
            }
            foreach (Customer c in DB.Read<Customer>())
            {
                Console.WriteLine(c);
            }
            */

            /*
            DateTime d1 = new DateTime(year: 2023, month: 10, day: 10, hour: 12, minute: 00, second:00);
            DateTime d2 = new DateTime(year: 2023, month: 10, day: 11);
            TimeSlot timeSlot = new TimeSlot(d1);
            TimeSlot timeSlot2 = new TimeSlot(d2);
            TimeSlot timeSlot3 = new TimeSlot(DateTime.Now);
            Console.WriteLine(timeSlot);
            Console.WriteLine(timeSlot2);
            Console.WriteLine(timeSlot3);
            */
            /* ---------------------------------------------------->START<------------------------------------------------------------------ */

            Console.WriteLine("Do you want to create a new user(1) or select a existing one(2)?");
            int answer = Convert.ToInt32(Console.ReadLine());
            if (answer == 1) {
                User user = User.Create();
                string UserType = user.GetType().Name;
                switch(UserType)
                {
                    case "Customer":
                        DB.Create<Customer>(user as Customer);
                        break;
                    case "Staff":
                        DB.Create<Staff>(user as Staff);
                        break;
                    case "Admin":
                        DB.Create<Admin>(user as Admin);
                        break;
                    case "Service":
                        DB.Create<Service>(user as Service);
                        break;
                    default: break;
                }
                Console.WriteLine($"This is your ID(save it--Or dont. see if i care.):{user.GetType().GUID}");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
            else if (answer == 2)
            {
                Console.WriteLine("Enter ID:");
                string id = Console.ReadLine();
                User user = User.GetUserById(DB, id);
                if (user != null) { Console.WriteLine("Get Bent.(No user)."); }
            }


            //Console.WriteLine(userDB.Read<Customer>("Id", "00e19739-d644-4f05-a042-fec4a9ca946a"));
            //User user = User.ChooseUserType(name, phone, email, id, choice);
            //userDB.Create<Customer>(user as Customer);

            int option = 0;
            do
            {
                Console.WriteLine("Option 1");
                Console.WriteLine("Option 2");
                Console.WriteLine("Option 3");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        break;
                    case 2:
                        Console.WriteLine("Option 2");
                        break;
                    case 3:
                        Console.WriteLine("Option 3");
                        break;
                    case 4:
                        Console.WriteLine("Exiting the menu...");
                        break;
                    default:
                        Console.WriteLine("Invalid option, no workie.");
                        break;
                }
                Console.WriteLine();
            } while (option != 4);
            
        }
        // Static methods for the program
    }
}