using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DVDLibrary.Models
{
   public class Actor
    {
        [Required(ErrorMessage = "What is the actors first name?")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "What is the actors last name?")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "What character did they play?")]
        public string CharName { get; set; }
    }
}
