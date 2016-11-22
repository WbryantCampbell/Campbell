using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Data.Repositories
{
    class InMemStateRepository : IStateRepository
    {
        private static List<States> _states;

        public InMemStateRepository()
        {
            if (_states == null)
            {
                _states = new List<States>()
                {
                    new States()
                    { 
                        State = "Ohio",
                        StateAbbrev = "OH",
                        TaxRate = 6.5m
                        
                    },

                    new States()
                    {
                        State = "California",
                        StateAbbrev = "CA",
                        TaxRate = 8.2m

                    },

                    new States()
                    {
                        State = "Pennslyvania",
                        StateAbbrev = "PA",
                        TaxRate = 6.5m

                    },

                    new States()
                    {
                        State = "Arizona",
                        StateAbbrev = "AZ",
                        TaxRate = 4.5m
                    }

                };
            } 
        }
        //public Dictionary<string, States> CreateStateDictionary()
        //{
        //    return _states.ToDictionary(state => state.StateAbbrev);
        //}

        public States FindByStateAbbreviation(string abbrev)
        {
            return _states.FirstOrDefault(a => a.StateAbbrev == abbrev);
        }

        public List<States> GetAllStates()
        {
            return _states;
        }
    }
}
