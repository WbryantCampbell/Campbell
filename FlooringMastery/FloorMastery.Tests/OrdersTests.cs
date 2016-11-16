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
    class OrdersTests
    {
        [Test]
        public void GetOrderTest()
        {
            DateTime date = DateTime.Parse("10/10/2016");
            OrderManager ops = new OrderManager();
            var response = ops.GetOrder(1, date);
            Assert.IsTrue(response.Success);

            Console.WriteLine(response.Order);
        }
    }
}
