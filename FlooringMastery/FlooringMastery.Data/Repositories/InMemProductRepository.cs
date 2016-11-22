using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.Repositories
{
    internal class InMemProductRepository : IProductRepository
    {
        private static List<Products> _products ;

        public InMemProductRepository()
        {
            if (_products == null)
            {
                _products = new List<Products>()
                {
                    new Products()
                    {
                        ProductName = "Concrete",
                        LaborCostSqFt = 7.0m,
                        MaterialCostSqFt = 4.0m
                    },

                    new Products()
                    {
                        ProductName = "WoodFlooring",
                        LaborCostSqFt = 7.0m,
                        MaterialCostSqFt = 4.0m
                    },

                    new Products()
                    {
                        ProductName = "Painted",
                        LaborCostSqFt = 7.0m,
                        MaterialCostSqFt = 1.5m
                    },

                    new Products()
                    {
                        ProductName = "Carpet",
                        LaborCostSqFt = 7.0m,
                        MaterialCostSqFt = 8.75m
                    }
                };
            }
        }
        public Products FindByProductName(string productName)
        {

            return _products.First(a => a.ProductName == productName);

        }

        public List<Products> GetAllProducts()
        {
            return _products;
        }
    }
}
