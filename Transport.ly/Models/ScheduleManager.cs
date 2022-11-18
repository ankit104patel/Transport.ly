using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Models
{
    public class ScheduleManager
    {
        public static string LoadedMessage(Schedule schedule)
        {
            return $"Schedule {schedule.FlightNumber} loaded";
        }
    }
}
