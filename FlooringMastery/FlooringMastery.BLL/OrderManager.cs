using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Data.Repositories;
using FlooringMastery.Models;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private readonly ErrorLog _log = new ErrorLog();



        public OrderResponse GetOrder(int orderNumber, DateTime date)
        {
            OrderResponse response = new OrderResponse();

            var repo = RepositoryFactory.CreateOrderRepository();
            var order = repo.GetOrderByNumber(orderNumber,date );

            //.GetOrderByNumber(orderNumber);

            if (order != null)
            {
                response.Success = true;
                response.Order = order;
            }
            else
            {
                response.Success = false;
                response.Message = $"No Order found for order number: {orderNumber}";
                Console.WriteLine($"{response.Message}");
                _log.LogIt(DateTime.Today, response.Message);
            }

            return response;
        }
        public OrderResponse GetOrdersByDate(DateTime date)
        {
            OrderResponse response = new OrderResponse();

            var repo = RepositoryFactory.CreateOrderRepository();
            var prod = repo.OrdersByDate(date)
            ;

            if (prod != null)
            {
                response.Success = true;
                response.List = prod;
            }
            else
            {
                //TODO: LOGIT
                response.Success = false;
                response.Message = $"No Orders found on the Date: {date}";
                Console.WriteLine($"{response.Message}");
                _log.LogIt(DateTime.Today, response.Message);
            }

            return response;
        }

        public OrderResponse AddOrder(Order order)
        {
            OrderResponse response = new OrderResponse();

            var repo = RepositoryFactory.CreateOrderRepository();
            var adding = repo.AddOrder(order);

            if (adding != null)
            {

                response.Success = true;
                response.Order = order;

            }
            else
            {
                //TODO: LOGGIT
                response.Success = false;
                response.Message = $"Could not add Order to Master List";
                Console.WriteLine($"{response.Message}");
                _log.LogIt(DateTime.Today, response.Message);
            }
            return response;
        }
        public OrderResponse RemoveOrder(Order order)
        {
            OrderResponse response = new OrderResponse();

            var repo = RepositoryFactory.CreateOrderRepository();

            var adding = repo.RemoveOrder(order);

            if (adding != false)
            {

                response.Success = true;
                response.Order = order;

            }
            else
            {
                //TODO: LOGGIT
                response.Success = false;
                response.Message = $"Could not remove Order to Master List";
                Console.WriteLine($"{response.Message}");
                _log.LogIt(DateTime.Today, response.Message);
            }
            return response;
        }

        public OrderResponse EditOrder(Order order, Order newOrder)
        {
            OrderResponse response = new OrderResponse();

            var repo = RepositoryFactory.CreateOrderRepository();

            var edit = repo.EditOrder(order, newOrder);

            if (edit)
            {
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = ($"Oops... something isn't right...");
                Console.WriteLine($"{response.Message}");
                _log.LogIt(DateTime.Today, response.Message);
            }
            return response;
        }


    }
}