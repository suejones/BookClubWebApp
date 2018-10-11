using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Abstract;
using WebApplication2.Models;

namespace WebApplication2.Tests.TestModels
{
    class TestBookClubContext : IBookClubContext
    {
        public TestBookClubContext()
        {
            this.Books = new TestBookDbSet();
            this.Reviews = new TestReviewDbSet();
            this.BookLists = new TestBookListDbSet();
            //this.Libraries = new TestLibraryDbSet();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookList> Libraries { get; set; }

        public int SaveChanges()
        {
            return 0;
        }

        public void MarkAsModified(object item) { }
        public void Dispose() { }
    }
}
