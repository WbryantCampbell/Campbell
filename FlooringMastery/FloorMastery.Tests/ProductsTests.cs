using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL;
using NUnit.Framework;

namespace FloorMastery.Tests
{
    [TestFixture]
    public class ProductsTests
    {
        [Test]
        public void GetProdTest()
        {
            string str = "WoodFlooring";
            ProductManager manager = new ProductManager();
            var response = manager.GetProdByName(str);
            Assert.IsTrue(response.Success);

            Console.WriteLine(response.Product);
        }
    }
}

