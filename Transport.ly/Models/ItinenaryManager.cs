using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Models
{
    public class ItinenaryManager
    {
        public static string Itinerary(Order order)
        {
            return order.IsNotLoaded() ? $"order: {order.Code}, flightNumber: not scheduled"
                : $"order: {order.Code}, flightNumber: {order.Schedule.FlightNumber}, departure: {order.Schedule.Departure}, arrival: {order.Schedule.Arrival}, day: {order.Schedule.Day}";
        }
    }
}
