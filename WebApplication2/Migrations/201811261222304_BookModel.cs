namespace WebApplication2
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "Book_BookISBN", c => c.Int());
            CreateIndex("dbo.Book", "Book_BookISBN");
            AddForeignKey("dbo.Book", "Book_BookISBN", "dbo.Book", "BookISBN");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "Book_BookISBN", "dbo.Book");
            DropIndex("dbo.Book", new[] { "Book_BookISBN" });
            DropColumn("dbo.Book", "Book_BookISBN");
        }
    }
}
