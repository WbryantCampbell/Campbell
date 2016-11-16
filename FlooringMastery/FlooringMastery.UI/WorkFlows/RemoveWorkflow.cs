using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.WorkFlows
{
    class RemoveWorkflow
    {
        OrderManager _orderManage = new OrderManager();
        private DateTime date;

        public RemoveWorkflow()
        {
           
            GetSpecificOrder();

        }
        public void OrderByDate()
        {
            DateTime date = GetDateFromUser();

            GetOrderByDate(date);
        }

        private void GetOrderByDate(DateTime date)
        {
            var list = GetOrderDateFromRepo(date);

            if (list != null)
            {
                DisplayList(list);
            }
            else
            {
                Console.WriteLine("Oops something went wrong");
            }
        }

        private void DisplayList(List<Order> list)
        {
            foreach (var order in list)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"Order Number : {order.OrderNumber}");
                Console.WriteLine($"Customer Name : {order.CustomerName}");
                Console.WriteLine($"Order Total : {order.OrderTotal:c}");
                Console.WriteLine("-------------------------------");
            }
        }

        private List<Order> GetOrderDateFromRepo(DateTime date)
        {
            var response = _orderManage.GetOrdersByDate(date);
            List<Order> orders = new List<Order>();

            if (response.Success)
            {
                orders = response.List;
            }
            return orders;
        }

        private DateTime GetDateFromUser()
        {
            Console.WriteLine("What date would you like to see Orders from?(MM/DD/YYYY)");
            string input = Console.ReadLine();

            date = DateTime.Parse(input);

            return date;

        }

        public void GetSpecificOrder()
        {
            date = GetDateFromUser();
            GetOrderByDate(date);
            int orderNum = GetOrderNumFromUser();
            
            GetOrderByNum(orderNum, date);
        }

        private int GetOrderNumFromUser()
        {
            int result;
            Console.WriteLine("Please enter an Order Number for full Order Details");
            string input = Console.ReadLine();

            int.TryParse(input, out result);

            return result;
        }

        public void GetOrderByNum(int orderNum, DateTime date)
        {
            var order = GetOrderFromRepo(orderNum, date);

            if (order != null)
            {
                DisplayOrder(order);
            }

        }

        private Order GetOrderFromRepo(int orderNum, DateTime date)
        {
            var response = _orderManage.GetOrder(orderNum, date);

            if (response.Success)
            {

                DisplayOrder(response.Order);
                AddOrderPrompt(response.Order);
                
                return response.Order;

            }
            else
            {
                //TODO: LOG IT
                Console.WriteLine("Error Occurred!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Try again...");
                Console.ReadLine();
            }
            return null;
        }

        private void DisplayOrder(Order order)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Order Information");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Name : {order.CustomerName}");
            Console.WriteLine($"Order Number : {order.OrderNumber}");
            Console.WriteLine($"State :  {order.State.State}");
            Console.WriteLine($"Tax Rate : {order.State.TaxRate}");
            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Order Details");
            Console.WriteLine("-------------------------------");
            Console.WriteLine();
            Console.WriteLine($"Product : {order.Product.ProductName}");
            Console.WriteLine($"Area : {order.Area}");
            Console.WriteLine($"Material Cost : {order.MaterialCost:c}");
            Console.WriteLine($"Labor : {order.LaborCost:c}");
            //TODO Bug here**** fix 
            Console.WriteLine($"Tax : {order.OrderTax:c}");
            Console.WriteLine($"Total : {order.OrderTotal:c}");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }
        public void AddOrderPrompt(Order order)
        {
            Console.WriteLine("Are you sure you want to Remove this order? (Y/N)");

            bool isValid = false;

            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Y":
                        _orderManage.RemoveOrder(order);
                        isValid = true;
                        break;
                    case "N":
                        isValid = true;
                        break;
                    default:
                        Console.WriteLine("Oops....Try Again");
                        break;
                }
            } while (isValid != true);
        }
    }
}
