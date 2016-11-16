using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;

namespace FlooringMastery.Data.Repositories
{
    internal class InMemOrderRepository : IOrderRepository
    {
        private static List<Order> _orders;

        public InMemOrderRepository()
        {
            if (_orders == null)
            {
                _orders = new List<Order>()
                {
                    new Order()
                    {
                        OrderNumber = 1,
                        CustomerName = "Randy Jones",
                        Area = 200,
                        LaborCost = 800,
                         MaterialCost = 750,
                        OrderTax = 6.5m,
                        OrderTotal = 2200,
                        State = new States {State = "Ohio", StateAbbrev = "OH", TaxRate = 6.5m },
                        Product = new Products {ProductName = "WoodFlooring", LaborCostSqFt= 6.5m, MaterialCostSqFt = 7.0m },
                        //little mistake 
                        //State = new States{StateAbbrev = "OH", State = "Ohio", TaxRate = 6.5m},
                        //Product = {LaborCostSqFt = 6.5m, MaterialCostSqFt = 7.0m, ProductName = "WoodFlooring"},
                        DateOrdered = DateTime.Parse("10/10/16")

                    },

                    new Order()
                    {
                        OrderNumber = 2,
                        CustomerName = "Peter Griffin",
                        Area = 654,
                        LaborCost = 856,
                        MaterialCost = 899,
                        OrderTax = 6.5m,
                        OrderTotal = 2200,
                        State = new States {StateAbbrev = "AZ", State = "Arizona", TaxRate = 4.5m},
                        Product = new Products {LaborCostSqFt = 6.5m, MaterialCostSqFt = 7.0m, ProductName = "Concrete"},
                        DateOrdered = DateTime.Parse("10/10/16")

                    },

                    new Order()
                    {
                        OrderNumber = 3,
                        CustomerName = "Rick Sanchez",
                        Area = 684,
                        LaborCost = 995,
                        MaterialCost = 2155,
                        OrderTax = 6.5m,
                        OrderTotal = 2200,
                        State = new States  {StateAbbrev = "OH", State = "Ohio", TaxRate = 6.5m},
                        Product = new Products {LaborCostSqFt = 6.5m, MaterialCostSqFt = 7.0m, ProductName = "WoodFlooring"},
                        DateOrdered = DateTime.Parse("10/9/16")

                    },

                    new Order()
                    {
                        OrderNumber = 4,
                        CustomerName = "Eric Cartman",
                        Area = 200,
                        LaborCost = 800,
                        MaterialCost = 750,
                        OrderTax = 6.5m,
                        OrderTotal = 2200,
                        State = new States {StateAbbrev = "PA", State = "Pennslyvania", TaxRate = 6.5m},
                        Product = new Products {LaborCostSqFt = 6.5m, MaterialCostSqFt = 2.0m, ProductName = "Painted"},
                        DateOrdered = DateTime.Parse("10/8/16")

                    },

                    new Order()
                    {
                        OrderNumber = 5,
                        CustomerName = "Dillon Francis",
                        Area = 200,
                        LaborCost = 800,
                        MaterialCost = 750,
                        OrderTax = 6.5m,
                        OrderTotal = 2200,
                        State = new States {StateAbbrev = "CA", State = "California", TaxRate = 8.2m},
                        Product = new Products {LaborCostSqFt = 6.5m, MaterialCostSqFt = 7.0m, ProductName = "Carpet"},
                        DateOrdered = DateTime.Parse("10/8/16")

                    }
                };


            }
        }

        public Order GetOrderByNumber(int orderNumber, DateTime date)
        {
            //TODO Exception!!
            var results = from o in _orders
                where o.DateOrdered == date
                select o;

            return results.FirstOrDefault(a => a.OrderNumber == orderNumber);
        }

        public List<Order> OrdersByDate(DateTime date)
        {
            var results = from o in _orders
                         where o.DateOrdered == date
                         select o;


            return results.ToList();
        }

        public Order AddOrder(Order order)
        {
           _orders.Add(order);

           return order;

        }

        public bool RemoveOrder(Order order)
        {
            if (order != null)
            {
                _orders.Remove(order);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditOrder(Order order, Order newOrder)
        {
            _orders.Remove(order);
            _orders.Add(newOrder);
            return true;
        }
    }
}
