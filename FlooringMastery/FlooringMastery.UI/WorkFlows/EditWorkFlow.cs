using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using FlooringMastery.Models;

namespace FlooringMastery.UI.WorkFlows
{
    class EditWorkFlow
    {
        private Order _newOrder = new Order();
        private OrderManager _orderManage = new OrderManager();
        private StateManager _stateManage = new StateManager();
        private ProductManager _productManage = new ProductManager();
        private DateTime date;

        public EditWorkFlow()
        {
       
            GetSpecificOrder();

        }

        private void OrderByDate()
        {
            date = GetDateFromUser();

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

            DateTime date = DateTime.Parse(input);

            return date;

        }

        private void GetSpecificOrder()
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

        private void GetOrderByNum(int orderNum, DateTime date)
        {
            GetOrderFromRepo(orderNum, date);

            //if (order != null)
            //{
            //    DisplayOrder(order);
            //}

        }

        private bool GetOrderFromRepo(int orderNum, DateTime date)
        {
            var response = _orderManage.GetOrder(orderNum, date);

            
            if (response.Success)
            {
                PromptUserForUpdates(response.Order);
            }
            
            //TODO: LOG IT
            if (response.Success == false)
            {
                Console.WriteLine("Error Occurred!");
                Console.WriteLine(response.Message);
                Console.WriteLine("Try again...");
                Console.ReadLine();
                return false;
            }
            return true;
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

        private void PromptUserForUpdates(Order order)
        {
            _newOrder.OrderNumber = order.OrderNumber;
            _newOrder.DateOrdered = order.DateOrdered;
          
            _newOrder.CustomerName = GetStringValue(order.CustomerName, "Customer Name");
            //get abbreviation && set state with StateManager
            _newOrder.State = GetStateFromRepo(GetStringValue(order.State.StateAbbrev, "State name (Use Abbreviation)"));
            //Get product name && set it to new OrderObj
            _newOrder.Product = GetProdFromRepo(GetStringValue(order.Product.ProductName, "Product"));
            //Get Area from user
            var str = GetStringValue(currentvalue: order.Area.ToString(), field: "Area");
            int num = int.Parse(str);
            _newOrder.Area = num;

            SetCosts();
            DisplayOrder(_newOrder);
            //AddOrderPrompt();

            if (AddOrderPrompt())
            {
                var response =_orderManage.EditOrder(order, _newOrder);
                if (response.Success)
                {
                    Console.WriteLine("Order successfully added!");
                }
            
            }
        }

        private string GetStringValue(string currentvalue, string field)
        {
            string newValue = "";

            Console.WriteLine($"{field} is currently {currentvalue}");
            Console.WriteLine($"What is the new {field}?(Press enter to keep original {field}");
            newValue = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newValue))
            {
                newValue = currentvalue;
            }


            return newValue;
        }

        private States GetStateFromRepo(string state)
        {

            var response = _stateManage.CheckState(state);

            if (response.Success)
            {
                _newOrder.State = response.State;
                _newOrder.State.State = response.State.State;
                _newOrder.State.StateAbbrev = response.State.StateAbbrev;
                _newOrder.State.TaxRate = response.State.TaxRate;
                return response.State;
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

        private Products GetProdFromRepo(string prod)
        {

            var response = _productManage.GetProdByName(prod);

            if (response.Success)

            {
                _newOrder.Product = response.Product;
                _newOrder.Product.LaborCostSqFt = response.Product.LaborCostSqFt;
                _newOrder.Product.MaterialCostSqFt = response.Product.MaterialCostSqFt;
                _newOrder.Product.ProductName = response.Product.ProductName;
                return response.Product;
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

        private void SetCosts()
        {
            var prod = _newOrder.Product;
            int area = (int) _newOrder.Area;

            _newOrder.LaborCost = _productManage.CalcLaborCost(prod, area);
            _newOrder.MaterialCost = _productManage.CalcMaterialCost(prod, area);

            _newOrder.OrderTax = _stateManage.CalcTax(_newOrder.LaborCost, _newOrder.State) + _stateManage.CalcTax(_newOrder.MaterialCost, _newOrder.State);

            _newOrder.OrderTotal = _newOrder.LaborCost + _newOrder.MaterialCost + _newOrder.OrderTax;

        }

        private bool AddOrderPrompt()
        {
            Console.WriteLine("Are you sure you keep these changes? (Y/N)");

            //bool isValid = false;

            do
            {
                string input = Console.ReadLine();
                switch (input)
                {
                    case "Y":
                        //isValid = true;
                        return true;
                    case "N":
                        //isValid = true;
                        return false;
                    default:
                        Console.WriteLine("Oops....Try Again");
                        break;
                }
            } while (true);
            
        }

    }
}


        
