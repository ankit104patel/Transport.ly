using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.ly.Models;

namespace Transport.ly
{
    public interface IOrderRepository
    {
        IList<Order> GetOrders();
    }
}
