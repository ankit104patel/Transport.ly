using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transport.ly.Models
{
    public class OrderRepository : IOrderRepository
    {
        public IList<Order> GetOrders()
        {
            string filepath = Environment.CurrentDirectory;
            var jsonString = FileReader.ReadAllText(filepath.Split(new String[] { "bin" }, StringSplitOptions.None)[0] + "\\Files\\coding-assigment-orders.json");

            var orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(jsonString).Select(p =>
            new Order { Code = p.Key, Destination = p.Value.Destination, Priority = int.Parse(p.Key.Substring(p.Key.LastIndexOf('-') + 1)) }).ToList();

            return orders;
        }
    }
}
