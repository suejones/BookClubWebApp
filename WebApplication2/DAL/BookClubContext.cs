using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication2.Abstract;
using WebApplication2.Models;

namespace WebApplication2.DAL
{
    public class BookClubContext : DbContext, IBookClubContext
    {
        public BookClubContext() : base("BookClubContext")
        {
               //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DbContext, EF6Console.Migrations.Configuration>());
            
        }
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<BookList> BookLists { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<BookClub> BookClubs { get; set; }

        //to prevent EF to pluralize table names
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public void MarkAsModified(Object item)
        {
            Entry(item).State = EntityState.Modified;
        }
    }
}