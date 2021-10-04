using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppointmentNotificationManager;

namespace AppointmentNotificationManager.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var appointmentManager = new AppointmentNotificationManager();
            var id = Guid.NewGuid().ToString();
            var now = DateTime.Now;

            var newICS = appointmentManager.GetICS(new Appointment
            {
                AllDayEvent = false,
                Attendees = new List<AppointmentUser>
                {
                    new AppointmentUser
                    {
                        DisplayName = "Name",
                        Email = "name@gmail.com"
                    },
                },
                Description = "ICS Description TEST",
                EndDate = now.AddDays(3),
                StartDate = now.AddDays(1),
                Id = "B1",
                Location = "Buenos Aires",
                Organizer = new AppointmentUser
                {
                    DisplayName = "OtherName",
                    Email = "other@gmail.com"
                },
                Subject = "ICS SUBJECT TEST",
                StampDate = now,
                Sequence = now.ToString("MMddHHmm")
                //EventType = 1
                //RecurrenceData = null,       
            }, NotificationMethodType.Update);

            File.WriteAllText(id + ".ics", newICS);
        }
    }
}
