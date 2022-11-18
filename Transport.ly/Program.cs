using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.ly.Models;

namespace Transport.ly
{
    class Program
    {
        static void Main(string[] args)
        {
            var inventory = new InventoryManager();

            SelectMenu(inventory);
        }

        //To select a Menu
        private static void SelectMenu(InventoryManager inventory)
        {
            int choice;
            Menu menu = new Menu();
            menu = GetMainMenu();

            do
            {
                choice = new MenuManager().ReadMenu(menu);
                MainMenuChoice(choice, inventory);
            } while (choice != menu.ExitValue);
        }

        private static void MainMenuChoice(int userChoice, InventoryManager inventory)
        {
            switch (userChoice)
            {
                case 1:
                    ReadMenuChoice(inventory);
                    break;
                case 2:
                    inventory.DisplayLoadedSchedules();
                    break;
                case 3:
                    inventory.DisplayFlightItineraries();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }


        private static void ReadMenuChoice(InventoryManager inventory)
        {
            int userChoice;
            Menu menu;

            do
            {
                menu = inventory.GetFlightScheduleMenu();
                userChoice = new MenuManager().ReadMenu(menu);
                inventory.ScheduleMenuUserChoice(userChoice);
            } while (userChoice != menu.ExitValue);
        }

        private static Menu GetMainMenu()
        {
            var menu = new Menu
            {
                Header = "Transport.ly",
                Items = new List<string>()
                {
                    "1. Load flight a schedule",
                    "2. All loaded flight schedules",
                    "3. Generate flight itineraries",
                }
            };

            menu.ExitValue = menu.Items.Count + 1;
            menu.Items.Add($"{menu.ExitValue}. Exit");

            return menu;
        }
    }
}
