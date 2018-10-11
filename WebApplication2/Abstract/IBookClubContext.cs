using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Abstract
{
    public interface IBookClubContext : IDisposable
    {
        DbSet<Book> Books { get; }
        DbSet<Review> Reviews { get; }
        DbSet<BookList> BookLists { get; }
        DbSet<Library> Libraries { get; }

        int SaveChanges();
        void MarkAsModified(Object item);
    }
}
