using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data
{
    public interface IOrderRepository
    {
        Order GetOrderByNumber(int orderNumber, DateTime date);
        List<Order> OrdersByDate(DateTime date);
        Order AddOrder(Order order);
        bool RemoveOrder(Order order);
        bool EditOrder(Order order, Order newOrder);
    }


}
