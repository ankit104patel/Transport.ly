using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Models
{
    public class InformationManager : MenuManager
    {
        public override int ReadMenu(Menu menu)
        {
            Console.WriteLine(menu.Header);

            foreach (var item in menu.Items)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nPress any key to return to main menu... ");
            Console.ReadKey();

            return 0;
        }
    }
}
