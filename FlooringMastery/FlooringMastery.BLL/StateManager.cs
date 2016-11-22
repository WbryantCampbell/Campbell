using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Data;
using FlooringMastery.Data.Repositories;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class StateManager
    {
        private readonly ErrorLog _log = new ErrorLog();

        public StateResponse CheckState(string stateName)
        {
            StateResponse response = new StateResponse();

            var repo = RepositoryFactory.CreateStateRepository();
            var state = repo.FindByStateAbbreviation(stateName);

            //Write code that checks dictionary for string as key
           
            if (state != null)
            {
                response.Success = true;
                response.State = state;
                return response;
            }
            else
            {
                //TODO: LOGIT
                response.Success = false;
                response.Message = $"SGFlooring is not currently servicing: {stateName}";
                Console.WriteLine($"{response.Message}");
                _log.LogIt(DateTime.Today, response.Message);
            }

            return response;
        }
        public decimal CalcTax(decimal cost, States state)
        {
            decimal taxrate = state.TaxRate*0.01m;

            decimal total = (cost * taxrate);

            return total;
        }

        public List<States> GetAllStates()
        {
            var repo = RepositoryFactory.CreateStateRepository();

            return repo.GetAllStates();
        } 
    }
}




