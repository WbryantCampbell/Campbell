using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class OrderResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Order Order { get; set; }
        public List<Order> List { get; set; }
    }
}
