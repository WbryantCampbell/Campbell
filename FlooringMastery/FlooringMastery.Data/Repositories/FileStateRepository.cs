using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.Repositories
{
    internal class FileStateRepository : IStateRepository
    {
        //public Dictionary<string, States> CreateStateDictionary()
        //{
        //    throw new NotImplementedException();
        //}

        public States FindByStateAbbreviation(string abbrev)
        {
            var state = ReadFromFile();
            return state.FirstOrDefault(a => a.StateAbbrev == abbrev);
        }

        private List<States> ReadFromFile()
        {
            var filename = @"C:\_repos\bryant-campbell-individual-work\FlooringMastery\Data\Repos\StateRepo.txt";

            List<States> stateList = new List<States>();

            using (StreamReader sr = File.OpenText(filename))
            {
                sr.ReadLine();

                string inputLine = "";
                while ((inputLine = sr.ReadLine()) != null)
                {
                    string[] inputParts = inputLine.Split(',');
                    States state = new States()
                    {

                        StateAbbrev = inputParts[0],
                        State = inputParts[1],
                        TaxRate = decimal.Parse(inputParts[2])
                    };

                    stateList.Add(state);
                }
            }
            return stateList;
        }
    }
}
