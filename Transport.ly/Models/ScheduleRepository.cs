using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.ly.Interfaces;

namespace Transport.ly.Models
{
    public class ScheduleRepository : IScheduleRepository
    {
        public IList<Schedule> GetSchedules()
        {
            //use implicitly typed variables
            var flightNo = 1;
            var day = 1;
            var schedules = new List<Schedule>();

            schedules.Add(new Schedule { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YYZ", Day = day, IsLoaded = false });
            schedules.Add(new Schedule { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YYC", Day = day, IsLoaded = false });
            schedules.Add(new Schedule { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YVR", Day = day, IsLoaded = false });

            day++;
            schedules.Add(new Schedule { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YYZ", Day = day, IsLoaded = false });
            schedules.Add(new Schedule { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YYC", Day = day, IsLoaded = false });
            schedules.Add(new Schedule { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YVR", Day = day, IsLoaded = false });

            return schedules;
        }
    }
}
