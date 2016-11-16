using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FlooringMastery.Data.Repositories;

namespace FlooringMastery.Data
{
    public class RepositoryFactory
    {
        public static IOrderRepository CreateOrderRepository()
        {
            IOrderRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemOrderRepository();
                    break;
                case "PROD":
                    repo = new FileOrderRepository();
                    break;
                default:
                    //TODO: LOG THIS SHIT
                    throw new Exception("Only Modes are TEST and PROD");
            }

            return repo;
        }

        public static IProductRepository CreateProductRepository()
        {
            IProductRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemProductRepository();
                    break;
                case "PROD":
                    repo = new FileProductRepository();
                    break;
                default:
                    //TODO: LOGGGIT
                    throw new Exception("Only Modes are TEST AND PROD");
            }
            return repo;
        }

        public static IStateRepository CreateStateRepository()
        {
            IStateRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemStateRepository();
                    break;
                case "PROD":
                    repo = new FileStateRepository();
                    break;
                default:
                    //TODO: KENNYLOGGINS
                    throw new Exception("Only Modes are TEST and PROD ");

            }
            return repo;
        }
    }
    
}
