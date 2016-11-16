using DVDLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Data.Interfaces
{
    public interface IDvdRepository
    {
        List<DVD> GetDvDs();

        DVD GetDvdByTitle(string dvdTitle);

        void AddDvd(DVD dvdToAdd);

        void DeleteDvd(DVD dvdToDelete);

        void EditDvd(DVD dvdToEdit);

        DVD GetDvdById(int id);
    }
}
