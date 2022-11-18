using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Models
{
    public class MenuManager
    {
        public virtual int ReadMenu(Menu menu)
        {
            Console.Clear();
            Console.WriteLine("{0}\n", menu.Header);

            foreach (var item in menu.Items)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nEnter choice: ");

            int userInput;
            int.TryParse(Console.ReadLine(), out userInput);

            return userInput;
        }
    }
}
