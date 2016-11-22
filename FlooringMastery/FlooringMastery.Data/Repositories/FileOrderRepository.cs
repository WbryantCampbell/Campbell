using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.Repositories
{
    class FileOrderRepository : IOrderRepository
    {
        private const string FILENAME = @"C:\_repos\bryant-campbell-individual-work\FlooringMastery\Data\Orders\";
        private const string FILEEXT = ".txt";

        public Order GetOrderByNumber(int orderNumber, DateTime date)
        {
            var orders = ReadFromFile(date);
            return orders.FirstOrDefault(a => a.OrderNumber == orderNumber);
        }

        public List<Order> OrdersByDate(DateTime date)
        {
            var orders = ReadFromFile(date);
            return orders;
        }

        public Order AddOrder(Order order)
        {
            var writeColums = false;

            var filename = FILENAME + order.DateOrdered.ToString("yyyy-MM-dd") + FILEEXT;
            if (!File.Exists(filename))
            {
                writeColums = true;
            }
            using (StreamWriter sr = File.AppendText(filename))
            {
                if (writeColums == true)
                {
                    //sr.WriteLine("CustomerName,OrderNumber,StateName,StateAbbrev,TaxRate,ProdLaborCostSqFt,ProdMaterialCostSqFt,ProdName,Area,OrderTotal,DateOrdered");
                    sr.WriteLine("OrderNumber,CustomerName,DateOrdered,Area,StateAbbrev,StateName,TaxRate,ProdName,MaterialCostSqFt,LaborCostSqFt,OrderTotal,OrderTax");
                }
                sr.WriteLine(order.ToOrderString());
            }
            return order;
        }

        public bool RemoveOrder(Order order)
        {

            var orders = ReadFromFile(order.DateOrdered);

            if (!orders.Any())
            {
                var filepath = FILENAME + order.DateOrdered.ToString() + FILEEXT;

                File.Delete(filepath);
                return false;
            }
            Order index = orders.FirstOrDefault(o => o.OrderNumber == order.OrderNumber);
            orders.Remove(index);
            WriteOrdersBack(orders, order.DateOrdered);
   
            return true;

        }

        public void WriteOrdersBack(List<Order> orders, DateTime date)
        {
            var filename = FILENAME + date.ToString("yyyy-MM-dd") + FILEEXT;

            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.WriteLine("OrderNumber, CustomerName, DateOrdered, Area, StateAbbrev, StateName, TaxRate, ProdName, MaterialCostSqFt, LaborCostSqFt, OrderTotal, OrderTax");
                foreach (var order in orders)
                {
                    sw.WriteLine(order.ToOrderString());
                }
            }
            
        }
        public bool EditOrder(Order order, Order newOrder)
        {
            RemoveOrder(order);
            AddOrder(newOrder);

            return true;
        }
        public List<Order> ReadFromFile(DateTime date)
        {
            var filename = FILENAME + date.ToString("yyyy-MM-dd") + FILEEXT;

            List<Order> orders = new List<Order>();

            if (File.Exists(filename))
            {
                using (StreamReader sr = File.OpenText(filename))
                {
                    string inputline = "";
                    sr.ReadLine();

                    
                    while ((inputline = sr.ReadLine()) != null)
                    {
                        string[] inputParts = inputline.Split(',');
                        Order newOrder = new Order() 
                        {
                            OrderNumber = int.Parse(inputParts[0]),
                            CustomerName = inputParts[1],
                            DateOrdered = DateTime.Parse(inputParts[2]),
                            Area = decimal.Parse(inputParts[3]),
                            State = new States() { StateAbbrev = inputParts[4] , State = inputParts[5], TaxRate = decimal.Parse(inputParts[6]) },
                            Product = new Products() { ProductName = inputParts[7], MaterialCostSqFt = decimal.Parse(inputParts[8]), LaborCostSqFt = decimal.Parse(inputParts[9]) },
                            OrderTotal = decimal.Parse(inputParts[10]),
                            OrderTax = decimal.Parse(inputParts[11])
                            
                        };
                        orders.Add(newOrder);
                    }
                }
            }
            return orders;
        }
    }
}

