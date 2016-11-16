using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.InMemRepos;
using DVDLibrary.Models;

namespace DVDLibrary.BLL
{
    public class DVDOperations
    {
        public List<DVD> GetAllDvds()
        {
            var repo = new InMemDvdRepository();
            return repo.GetDvDs();
        }

        public DVD GetDvdByTitle(string title)
        {
            string upperTitle = title.ToUpper();
            var repo = new InMemDvdRepository();
            return repo.GetDvdByTitle(upperTitle);
        }

        public void Add(DVD dvd)
        {
            var dvds = GetAllDvds();
            dvd.id = (dvds.Any()) ? dvds.Max(c => c.id) + 1 : 1;
            var repo = new InMemDvdRepository();
            repo.AddDvd(dvd);
        }

        public void Delete(DVD dvd)
        {
            var repo = new InMemDvdRepository();
            repo.DeleteDvd(dvd);
        }

        public void Edit(DVD dvd)
        {
            var repo = new InMemDvdRepository();
            repo.EditDvd(dvd);
        }

        public DVD GetDvdById(int id)
        {
            var repo = new InMemDvdRepository();
            var dvd = repo.GetDvdById(id);
            return dvd;
        }

        public void SaveBorrowerInfo(DVD dvd)
        {
            var repo = new InMemDvdRepository();
            repo.SaveBorrower(dvd);
        }
    }
}
