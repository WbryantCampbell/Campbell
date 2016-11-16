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
    public class StatesTests
    {
        [Test]
        public void GetStateTest()
        {
            string str = "OH";
            StateManager manager = new StateManager();
            var response = manager.CheckState(str);
            Assert.IsTrue(response.Success);

            Console.WriteLine(response.State);
        }
    }
}
