using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibrary.Models
{
   public class DVD 
    {
        public int id { get; set; }

        [Required(ErrorMessage = "The Movie Must have a title!")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "When was it released?")]
        public DateTime? ReleaseDate { get; set; }

        [Required(ErrorMessage = "What is the movies rating?")]
        public MPAA? MPAA { get; set; }
        
        [Required(ErrorMessage = "Who Directed the movie?")]
        public string DirectorName { get; set; }

        [Required(ErrorMessage = "Who propduced it?")]
        public string Studio { get; set; }

        public double UserRating { get; set; }

       // public int UserRating { get; set; }

        public string UserNotes { get; set; }

        //[Required(ErrorMessage = "Who was in it?")]
        //public string Actor1 { get; set; }
        //[Required(ErrorMessage = "Who was in it?")]
        //public string Actor2 { get; set; }
        //[Required(ErrorMessage = "Who was in it?")]
        //public string Actor3 { get; set; }

        public List<Actor> Actors { get; set; }

        public Borrower Borrwer { get; set; }

    }
}
