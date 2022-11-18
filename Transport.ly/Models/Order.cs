using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Models
{
    public class Order
    {
        public int Priority { get; set; }
        public string Code { get; set; }
        public string Destination { get; set; }
        public Schedule Schedule { get; set; }

        public bool IsNotLoaded()
        {
            return Schedule == null;
        }
    }
}
