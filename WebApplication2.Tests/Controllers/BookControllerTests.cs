using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApplication2.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Abstract;
using WebApplication2.Tests.TestModels;
using WebApplication2.Models;
using System.Web.Mvc;

namespace WebApplication2.Controllers.Tests
{
    [TestClass()]
    public class BookControllerTests
    {
        [TestMethod()]
        public void BookControllerTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BookControllerTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void IndexTest()
        {
            TestBookClubContext tc = new TestBookClubContext();
            Book testbook1 = new Book { BookISBN = 123, BookName = "The Story" };
            Book testbook2 = new Book { BookISBN = 456, BookName = "To Kill a Mocking Bird" };

            tc.Books.Add(testbook1);
            tc.Books.Add(testbook2);

            var controller = new BookController(tc);

            var viewResult = controller.Index() as ViewResult;
            Book[] result = ((IEnumerable<Book>)viewResult.ViewData.Model).ToArray();

            Assert.AreEqual(2, result.Length);
        }

        [TestMethod()]
        public void DetailsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EditTest1()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteConfirmedTest()
        {
            Assert.Fail();
        }
    }
}