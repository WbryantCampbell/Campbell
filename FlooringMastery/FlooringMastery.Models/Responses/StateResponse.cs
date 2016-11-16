using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlooringMastery.Models.Responses
{
    public class StateResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public States State { get; set; }
    }
}
