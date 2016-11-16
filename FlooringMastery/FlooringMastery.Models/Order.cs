using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models
{
    public class Order
    {
        public int OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public DateTime DateOrdered { get; set; }
        public decimal Area { get; set; }
        public decimal LaborCost { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderTotal { get; set; }
        public States State { get; set; }
        public Products Product { get; set; }

        public string ToOrderString()
        {
            return this.OrderNumber + "," + CustomerName + "," + Convert.ToString(DateOrdered) + "," +
                   Convert.ToString(Area) + "," + State.StateAbbrev
                   + "," + State.State + "," + Convert.ToString(State.TaxRate) + "," +
                   Product.ProductName + "," + Convert.ToString(Product.MaterialCostSqFt) + ","
                   + Convert.ToString(Product.LaborCostSqFt) + "," + Convert.ToString(OrderTotal) + "," +
                   Convert.ToString(OrderTax);
        }

    }
}
//CustomerName,OrderNumber,StateName,StateAbbrev,TaxRate,ProdLaborCostSqFt,ProdMaterialCostSqFt,ProdName,Area,OrderTotal,DateOrdered
