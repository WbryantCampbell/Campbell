using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.BLL;


//TODO: Fix State tax rate in display and validation... also order number
namespace FlooringMastery.UI.WorkFlows
{
    public class AddWorkFlow
    {
        Order order = new Order();
        OrderManager orderManage = new OrderManager();
        ProductManager productManage = new ProductManager();
        StateManager stateManage = new StateManager();

        public AddWorkFlow()
        {
            Execute();
            AddProd();
            SetCosts();
            DisplayOrder(order);
            AddOrderPrompt();

        }
        public void Execute()
        {
            DateTime date = GetDate();

            AddOrderName(date);

        }

        private DateTime GetDate()
        {
            var date = DateTime.Today;
            SetOrderNumber(date);
            return date;
        }

        private void AddOrderName(DateTime date)
        {
            //TODO: Figure out states, prod, and ordernum rest is set by User
            order.DateOrdered = date;
            Console.WriteLine("What is the Customers Name?");
            order.CustomerName = Console.ReadLine();
            Console.Clear();
            string state = GetStateFromUser();
            order.State = GetStateFromRepo(state); 
        }

        private string GetStateFromUser()
        {
            //TODO: Validate for correct input
            Console.WriteLine("What State is the Customer in? Please use Abbreviation");
            string state = Console.ReadLine();
           
            return state;

        }

        private States GetStateFromRepo(string state)
        {
            
            var response = stateManage.CheckState(state);

            if (response.Success)
            {
                order.State = response.State;
                order.State.State = response.State.State;
                order.State.StateAbbrev = response.State.StateAbbrev;
                order.State.TaxRate = response.State.TaxRate;
                return response.State;
            }
            else
            {
                //TODO: LOG IT
                Console.WriteLine("Error Occurred!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Try again...");
                Console.ReadLine();
                MainMenu menu = new MainMenu();
                menu.Display();
                
            }
            return null;
        }

        private string GetProdFromUser()
        {
            //TODO:Validate and possibly make a list prods method in BLL that's called in workflow
            Console.WriteLine("What flooring would the Customer like?");
           string prod = Console.ReadLine();

            return prod;

        }

        private void AddProd()
        {
            string prod = GetProdFromUser();
            order.Product = GetProdFromRepo(prod);

        }

        private Products GetProdFromRepo(string prod)
        {
            
            var response = productManage.GetProdByName(prod);

            if (response.Success)

            {
                order.Product = response.Product;
                order.Product.LaborCostSqFt = response.Product.LaborCostSqFt;
                order.Product.MaterialCostSqFt = response.Product.MaterialCostSqFt;
                order.Product.ProductName = response.Product.ProductName;
                return response.Product;
            }
            else
            {
                //TODO: LOG IT
                Console.WriteLine("Error Occurred!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Try again...");
                Console.ReadLine();
                MainMenu menu = new MainMenu();
                menu.Display();
            }
            return null;
        }

        private int GetAreaFromUser()
        {
            int areaP = 0;
            Console.WriteLine("What is the total Area of the flooring needed?");
            string area = Console.ReadLine();
            while (true)
            {
                //Console.WriteLine("What is the total Area of the flooring needed?");
                //string area = Console.ReadLine();
                if (area != null) int.TryParse(area, out areaP);
                if (areaP > 0 || areaP < 2500000)
                {
                    order.Area = areaP;
                    break;
                }
                else
                {
                    Console.WriteLine("Oops try again");
                }
            }
            
            return areaP;
        }

        private void SetCosts()
        {
            var prod = order.Product;
            int area = GetAreaFromUser();

            order.LaborCost = productManage.CalcLaborCost(prod, area);
            order.MaterialCost = productManage.CalcMaterialCost(prod, area);

            order.OrderTax = stateManage.CalcTax(order.LaborCost, order.State) + stateManage.CalcTax(order.MaterialCost, order.State);

            order.OrderTotal = order.LaborCost + order.MaterialCost + order.OrderTax;

        }
        private List<Order> SetOrderNumber(DateTime date)
        {
            var response = orderManage.GetOrdersByDate(date);
            List<Order> orders = new List<Order>();

            if (response.Success)
            {
                orders = response.List;
                order.OrderNumber = (orders.Any()) ? orders.Max(c => c.OrderNumber) + 1 : 1;

            }
            return orders;
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
            Console.WriteLine($"Tax : {order.OrderTax:c}");
            Console.WriteLine($"Total : {order.OrderTotal:c}");
            Console.WriteLine("");
            Console.WriteLine("Press Enter to Continue");
            Console.ReadLine();
        }

        public void AddOrderPrompt()
        {
            Console.WriteLine("Are you sure you want to add this order? (Y/N)");
            
            bool isValid = false;

            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Y":
                        orderManage.AddOrder(order);
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
