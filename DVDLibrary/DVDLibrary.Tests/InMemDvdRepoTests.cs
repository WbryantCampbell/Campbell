using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.BLL;
using DVDLibrary.Models;
using NUnit.Framework;

namespace DVDLibrary.Tests
{
    [TestFixture]
    public class InMemDvdRepoTests
    {
        //CONSTRUCTOR 
        private DVDOperations ops = new DVDOperations();

        [Test]
        public void TestGetListOfDvds()
        {
            var results = ops.GetAllDvds();
            Assert.AreEqual(3, results.Count);
        }

        [Test]
        public void TestGetDvdByTitle()
        {
            string title = "The Big Lebowski";
            var result = ops.GetDvdByTitle(title);
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestAddBll()
        {
            var DvdToAdd = new DVD()
            {
                id = 1,
                Title = "Ryan Smells",
                ReleaseDate = DateTime.Parse("9/2/2016"),
                MPAA = MPAA.R,
                DirectorName = "Christian Springer",
                Studio = "Jaggered Arrays",
                UserRating = 5,
                UserNotes = "The Life and Times Of Ryan",
                Actors = new List<Actor>()
                {
                    new Actor()
                    {
                        FirstName = "Jake",
                        LastName = "Ala",
                        CharName = "Big Red"
                    },
                    new Actor()
                    {
                        FirstName = "Zach",
                        LastName = "Marx",
                        CharName = "Teach"
                    },
                    new Actor()
                    {
                        FirstName = "Ryan",
                        LastName = "Rober",
                        CharName = "Smelly"
                    }
                },
                Borrwer = new Borrower()
                {
                    Name = "Dan",
                    DateBorrowed = DateTime.Parse("9/3/16"),
                    DateReturned = null,
                    isReturned = false
                }
            };
            ops.Add(DvdToAdd);
            var results = ops.GetAllDvds();
            Assert.AreEqual(4, results.Count);
        }

        [Test]
        public void TestDeleteDvd()
        {
            var DvdToDelete = ops.GetDvdByTitle("The Big Lebowski");
            Assert.AreEqual(2,DvdToDelete.id);
            ops.Delete(DvdToDelete);
            var dvds = ops.GetAllDvds();
            Assert.AreEqual(2,dvds.Count);
        }

        [Test]
        public void TestEditDvd()
        {
            var DvdToEdit = ops.GetDvdByTitle("The Big Lebowski");
            Assert.IsNotNull(DvdToEdit);
            DvdToEdit.Title = "The Greatest Movie Ever";
            ops.Edit(DvdToEdit);
            var returnedDvd = ops.GetDvdByTitle("The Greatest Movie Ever");
            Assert.IsNotNull(returnedDvd);
        }
    }
}
