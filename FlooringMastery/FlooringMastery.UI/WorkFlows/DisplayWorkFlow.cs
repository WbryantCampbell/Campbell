using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.BLL;

namespace FlooringMastery.UI.WorkFlows
{
    public class DisplayWorkFlow
    {
        readonly OrderManager _orderManage = new OrderManager();
        readonly ProductManager _productManage = new ProductManager();
        readonly StateManager _stateManage = new StateManager();

        DateTime _date;

        public DisplayWorkFlow()
        {
            GetSpecificOrder();
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
            else
            {
                Console.WriteLine(response.Message);
                MainMenu menu = new MainMenu();
                menu.Display();
            }
            return orders;
        }

        private DateTime GetDateFromUser()
        {
            Console.WriteLine("What date would you like to see Orders from?(MM/DD/YYYY)");
            string input = Console.ReadLine();

            _date = DateTime.Parse(input);

            GetOrderDateFromRepo(_date);

            return _date;

        }

        public void GetSpecificOrder()
        {
            _date = GetDateFromUser();
            GetOrderByDate(_date);
            int orderNum = GetOrderNumFromUser();
           
            GetOrderByNum(orderNum, _date);
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
                SetCosts(order);
                DisplayOrder(order);
            }
            else
            {
                Console.ReadLine();
                MainMenu menu = new MainMenu();
                menu.Display();
            }

        }

        private Order GetOrderFromRepo(int orderNum, DateTime date)
        { 
            var response = _orderManage.GetOrder(orderNum, date);

            if (response.Success)
            {
                return response.Order;
            }
            else
            {
                //TODO: LOG IT
                Console.WriteLine("Error Occurred!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Try again...");
                MainMenu menu = new MainMenu();
                menu.Display();
                Console.ReadLine();
            }
            return null;
        }
        private void SetCosts(Order order)
        {
            var prod = order.Product;
            decimal area = order.Area ;

            order.LaborCost = _productManage.CalcLaborCost(prod, area);
            order.MaterialCost = _productManage.CalcMaterialCost(prod, area);

            order.OrderTax = _stateManage.CalcTax(order.LaborCost, order.State) + _stateManage.CalcTax(order.MaterialCost, order.State);

            order.OrderTotal = order.LaborCost + order.MaterialCost + order.OrderTax;

        }

        //private void DisplayOrder(Order order)
        //{
        //    Console.Clear();
        //    Console.WriteLine();
        //    Console.WriteLine("Order Information");
        //    Console.WriteLine("------------------------------");
        //    Console.WriteLine();
        //    Console.WriteLine($"Name : {order.CustomerName}");
        //    Console.WriteLine($"Order Number : {order.OrderNumber}");
        //    Console.WriteLine($"State :  {order.State.State}");
        //    Console.WriteLine($"Tax Rate : {order.State.TaxRate}");
        //    Console.WriteLine();
        //    Console.WriteLine("-------------------------------");
        //    Console.WriteLine("Order Details");
        //    Console.WriteLine("-------------------------------");
        //    Console.WriteLine();
        //    Console.WriteLine($"Product : {order.Product.ProductName}");
        //    Console.WriteLine($"Area : {order.Area}");
        //    Console.WriteLine($"Material Cost : {order.:c}");
        //    Console.WriteLine($"Labor : {order.Product.LaborCostSqFt:c}");
        //    //TODO Bug here**** fix 
        //    Console.WriteLine($"Tax : {order.OrderTax:c}");
        //    Console.WriteLine($"Total : {order.OrderTotal:c}");
        //    Console.WriteLine("");
        //    Console.WriteLine("Press Enter to Continue");
        //    Console.ReadLine();
        //}
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
            Console.WriteLine($"Tax : {order.OrderTax:c}");
            Console.WriteLine($"Total : {order.OrderTotal:c}");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }


    }
}