using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Models
{
    public class InventoryManager
    {
        public IList<Order> Orders { get; private set; }
        public IList<Flight> FlightsScheduled { get; private set; }
        public IList<Schedule> Schedules { get; private set; }

        public InventoryManager()
        {
            FlightsScheduled = new List<Flight>();
            Schedules = new ScheduleRepository().GetSchedules();
        }

        public void ScheduleMenuUserChoice(int userChoice)
        {
            if (userChoice > 0 && userChoice <= Schedules.Count)
            {
                var selectedFlightSchedule = Schedules.FirstOrDefault(s => !s.IsLoaded && s.FlightNumber == userChoice);
                if (selectedFlightSchedule != null)
                {
                    var scheduledFlight = new Flight(20, selectedFlightSchedule);
                    FlightsScheduled.Add(scheduledFlight);
                    FlightsScheduled = FlightsScheduled.OrderBy(f => f.Schedule.FlightNumber).ToList();
                    DisplayScheduleLoadedMessage(selectedFlightSchedule);
                }
            }
        }

        public void DisplayScheduleLoadedMessage(Schedule schedule)
        {
            var menu = new Menu()
            {
                Items = new List<string>()
            {
                $"{ScheduleManager.LoadedMessage(schedule)}"
            }
            };

            new InformationManager().ReadMenu(menu);
        }

        public void DisplayLoadedSchedules()
        {
            var menu = new Menu()
            {
                Header = "\nschedules Loaded\n"
            };

            foreach (var flight in FlightsScheduled)
            {
                menu.Items.Add(flight.FlightSchedule());
            }

            new InformationManager().ReadMenu(menu);
        }

        public void DisplayFlightItineraries()
        {
            LoadOrdersInFlights();

            var menu = new Menu()
            {
                Header = "\n Flight itineraries\n"
            };

            foreach (var order in Orders)
            {
                menu.Items.Add(ItinenaryManager.Itinerary(order));
            }

            new InformationManager().ReadMenu(menu);
        }

        private void LoadOrdersInFlights()
        {
            Orders = new OrderRepository().GetOrders().OrderBy(o => o.Priority).ToList();

            foreach (var schedule in Schedules)
            {
                if (schedule.IsLoaded)
                {
                    var loadedFlights = FlightsScheduled.Where(f => f.Schedule == schedule).ToList();

                    foreach (var flight in loadedFlights)
                    {
                        var flightOrders = Orders.Where(o => o.IsNotLoaded() && o.Destination == schedule.Arrival).Take(flight.Capacity).Select(o => { o.Schedule = schedule; return o; }).ToList();
                        flight.Orders = flightOrders;
                    }
                }
            }
        }

        public Menu GetFlightScheduleMenu()
        {
            var menu = new Menu
            {
                Header = "Select Menu to load a schedule"
            };

            foreach (var item in Schedules)
            {
                if (!item.IsLoaded)
                {
                    menu.Items.Add(item.ToString());
                }
            }

            menu.ExitValue = Schedules.Count + 1;
            menu.Items.Add($"{menu.ExitValue}. Main menu");

            return menu;
        }
    }
}
