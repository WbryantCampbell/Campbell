using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Data.Repositories;
using FlooringMastery.Models;
////using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class ProductManager
    {
        private readonly ErrorLog _log = new ErrorLog();

       public ProductManager()
        {
           

        }

        public ProductResponse GetProdByName(string prodName)
        {
            ProductResponse response = new ProductResponse();

            var repo = RepositoryFactory.CreateProductRepository();
            var prod = repo.FindByProductName(prodName);

            if (prod != null)
            {
                response.Success = true;
                response.Product = prod;
            }
            else
            {
                //TODO: LOGIT
                response.Success = false;
                response.Message = $"No Product found by the name: {prodName}";
                Console.WriteLine($"{response.Message}");
                _log.LogIt(DateTime.Today, response.Message);
            }

            return response;
        }

        public List<Products> GetAllProducts()
        {
            var repo = RepositoryFactory.CreateProductRepository();

            return repo.GetAllProducts();
        }

        public decimal CalcLaborCost(Products product, decimal area)
        {
            decimal x = product.LaborCostSqFt;
            decimal y = area;

            decimal total = x*y;
            return total;
        }

        public decimal CalcMaterialCost(Products product, decimal area)
        {
            decimal x = product.MaterialCostSqFt;
            decimal y = area;

            decimal total = x * y;
            return total;
        }



    }
}
