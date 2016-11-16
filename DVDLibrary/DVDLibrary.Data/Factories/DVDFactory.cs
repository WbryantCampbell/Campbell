using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.InMemRepos;
using DVDLibrary.Data.Interfaces;

namespace DVDLibrary.Data.Factories
{
    public class DVDFactory
    {
        public IDvdRepository CreatDvdRepository()
        {
            IDvdRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();
            switch (mode)
            {
                case "test":
                    repo = new InMemDvdRepository();
                    break;
                default:
                    throw  new Exception($"{mode} is not a recognized configuration");
            }
            return repo;
        }
    }
}
