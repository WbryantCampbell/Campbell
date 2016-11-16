using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;


namespace FlooringMastery.Data
{
    public interface IProductRepository
    {
        Products FindByProductName(string productName);
    }
}
