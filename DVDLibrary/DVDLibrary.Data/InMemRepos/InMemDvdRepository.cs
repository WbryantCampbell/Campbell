using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.Data.Interfaces;
using DVDLibrary.Models;

namespace DVDLibrary.Data.InMemRepos
{
    public class InMemDvdRepository : IDvdRepository
    {
        private static List<DVD> _dvds;

        public InMemDvdRepository()
        {
            if (_dvds == null)
            {
                _dvds = new List<DVD>()
                {
                    new DVD()
                    {
                        id = 1,
                        Title = "Jurassic Park",
                        ReleaseDate = DateTime.Parse("06/11/93"),
                        MPAA = MPAA.PG,
                        DirectorName = "Steven Spielberg",
                        Studio = "Universal Studios",
                        UserRating = 5,
                        UserNotes = "Shirtless Jeff Goldblum 10/10",
                        Actors = new List<Actor>()
                        {
                            new Actor()
                            {
                                FirstName = "Sam ",
                                LastName = "Neill",
                                CharName = "Dr. Alan Grant"
                            },
                            new Actor()
                            {
                                FirstName = "Laura",
                                LastName = "Dern",
                                CharName = " Dr. Ellie Satler"
                            },
                            new Actor()
                            {
                                FirstName = "Jeff",
                                LastName = "Golblum",
                                CharName = "Dr. Ian Malcolm"
                            }
                        },
                        Borrwer = new Borrower()
                        {
                            Name = "Jacob",
                            DateBorrowed = DateTime.Parse("11/09/16"),
                            DateReturned = null,
                            isReturned = false
                        }
                    },
                    new DVD()
                    {
                        id = 2,
                        Title = "Aliens",
                        ReleaseDate = DateTime.Parse("7/18/86"),
                        MPAA = MPAA.R,
                        DirectorName = "James Cameron",
                        Studio = "Pinewood",
                        UserRating = 5,
                        UserNotes = "It's game over man",
                        Actors = new List<Actor>()
                        {
                            new Actor()
                            {
                                FirstName = "Sigourney",
                                LastName = "Weaver",
                                CharName = "Lt. Ellen Riples"
                            },
                            new Actor()
                            {
                                FirstName = "Carrie",
                                LastName = "Henn",
                                CharName = "Newt"
                            },
                            new Actor()
                            {
                                FirstName = "Micheal",
                                LastName = "Beign",
                                CharName = "Corporal Dwayne Hicks"

                            }
                        },
                        Borrwer = new Borrower()
                        {
                            Name = "Bryant",
                            DateBorrowed = DateTime.Parse("11/10/16"),
                            DateReturned = DateTime.Parse("11/11/16"),
                            isReturned = true,
                        }
                    },
                    new DVD()
                    {
                        id = 3,
                        Title = "Star Wars: Episode VII - The Force Awakens" ,
                        ReleaseDate = DateTime.Parse("12/18/15"),
                        MPAA = MPAA.PG13,
                        DirectorName = "J.J. Abrams",
                        Studio = "Walt Disney",
                        UserRating = 4.5,
                        UserNotes = "Rey is Bae",
                        Actors = new List<Actor>()
                        {
                            new Actor()
                            {
                                FirstName = "Harrison",
                                LastName = "Ford",
                                CharName = "Han Solo"
                            },
                            new Actor()
                            {
                                FirstName = "Daisy",
                                LastName = "Ridley",
                                CharName = "Rey"
                            },
                            new Actor()
                            {
                                FirstName = "John",
                                LastName = "Boyega",
                                CharName = "Finn"
                            }
                        },
                        Borrwer = new Borrower()
                        {
                            Name = "Josh",
                            DateBorrowed = DateTime.Parse("11/10/16"),
                            DateReturned = DateTime.Parse("11/11/16"),
                            isReturned = true,
                        }
                    },
                    new DVD()
                    {
                        id = 4,
                        Title = "Warcraft",
                        ReleaseDate = DateTime.Parse("06/10/16"),
                        MPAA = MPAA.PG13,
                        DirectorName = "Duncan Jones",
                        Studio = "Legendary Pictures",
                        UserRating = 4,
                        UserNotes = "Orcs, elves, and dwarfs oh my",
                        Actors = new List<Actor>()
                        {
                            new Actor()
                            {
                                FirstName = "Travis",
                                LastName = "Fimmel",
                                CharName = "Andun Lothar"
                            },
                            new Actor()
                            {
                                FirstName = "Paula",
                                LastName = "Patton",
                                CharName = "Garona"
                            }
                        }
                    }
                };
            }
        }

        public List<DVD> GetDvDs()
        {
            return _dvds;
        }

        public DVD GetDvdByTitle(string dvdTitle)
        {
            return _dvds.FirstOrDefault(d => d.Title.ToUpper() == dvdTitle);
        }

        public void AddDvd(DVD dvdToAdd)
        {
            _dvds.Add(dvdToAdd);
        }

        public void DeleteDvd(DVD dvdToDelete)
        {
            var result = _dvds.FirstOrDefault(d => d.id == dvdToDelete.id);
            _dvds.Remove(result);
        }

        public void EditDvd(DVD dvdToEdit)
        {

            var dvd = _dvds.FirstOrDefault(d => d.id == dvdToEdit.id);
            _dvds.Remove(dvd);
            dvd = dvdToEdit;
            _dvds.Add(dvd);
        }

        public DVD GetDvdById(int id)
        {
            return _dvds.FirstOrDefault(d => d.id == id);
        }

        public void SaveBorrower(DVD dvdWithBorrower)
        {
            var dvd = GetDvdById(dvdWithBorrower.id);
            dvd.Borrwer = dvdWithBorrower.Borrwer;
            EditDvd(dvd);
        }
    }
}
