using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Tests.TestModels
{
    class TestBookDbSet : TestDbSet<Book>
    {
        public override Book Find(params object[] keyValues)
        {
            return this.SingleOrDefault(book => book.BookISBN == (int)keyValues.Single());
        }
    }
    class TestBookListDbSet : TestDbSet<BookList>
    {
        public override BookList Find(params object[] keyValues)
        {
            return this.SingleOrDefault(bookList => bookList.BookListID == (int)keyValues.Single());
        }
    }
    class TestReviewDbSet : TestDbSet<Review>
    {
        public override Review Find(params object[] keyValues)
        {
            return this.SingleOrDefault(review => review.ReviewID == (int)keyValues.Single());
        }
    }
    class TestLibraryDbSet : TestDbSet<Library>
    {
        public override Library Find(params object[] keyValues)
        {
            return this.SingleOrDefault(library => library.LibraryID == (int)keyValues.Single());
        }
    }
    class TestBookClubDbSet : TestDbSet<BookClub>
    {
        public override BookClub Find(params object[] keyValues)
        {
            return this.SingleOrDefault(bookClub => bookClub.BookClubID == (int)keyValues.Single());
        }
    }
}
