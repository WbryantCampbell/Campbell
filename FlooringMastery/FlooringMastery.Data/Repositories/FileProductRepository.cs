using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.Repositories
{
    public class FileProductRepository : IProductRepository 
    {
        public Products FindByProductName(string productName)
        {
            var prod = ReadFromFile();
            return prod.FirstOrDefault(a => a.ProductName == productName);
        }

        public List<Products> GetAllProducts()
        {
            var list = ReadFromFile();
            return list;
        }

        private List<Products> ReadFromFile()
        {
            var filename = @"C:\_repos\bryant-campbell-individual-work\FlooringMastery\Data\Repos\ProductRepo.txt";

            List<Products> prodList = new List<Products>();

            using (StreamReader sr = File.OpenText(filename))
            {
                sr.ReadLine();

                string inputLine = "";
                while ((inputLine = sr.ReadLine()) != null)
                {
                    string[] inputParts = inputLine.Split(',');
                    Products prod = new Products()
                    {
                        ProductName = inputParts[0],
                        MaterialCostSqFt = decimal.Parse(inputParts[1]),
                        LaborCostSqFt = decimal.Parse(inputParts[2])
                        
                    };

                    prodList.Add(prod);
                }
            }
            return prodList;
        }
    }
}
