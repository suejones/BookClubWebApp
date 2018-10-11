namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookClubWebAppv11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookList",
                c => new
                    {
                        BookListID = c.Int(nullable: false, identity: true),
                        BookListName = c.String(nullable: false, maxLength: 55),
                        BookListType = c.String(nullable: false),
                        BookListContent = c.String(nullable: false),
                        GenreType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookListID);
            
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookISBN = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false, maxLength: 55),
                        AuthorFirstName = c.String(nullable: false, maxLength: 55),
                        AuthorLastName = c.String(nullable: false, maxLength: 55),
                        Genre = c.Int(nullable: false),
                        GenreType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookISBN);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        UserID = c.String(),
                        BookISBN = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.Book", t => t.BookISBN, cascadeDelete: true)
                .Index(t => t.BookISBN);
            
            CreateTable(
                "dbo.Library",
                c => new
                    {
                        LibraryID = c.Int(nullable: false, identity: true),
                        LibraryName = c.String(nullable: false, maxLength: 55),
                        LibraryEmail = c.String(nullable: false),
                        Province = c.String(nullable: false),
                        County = c.String(nullable: false),
                        Area = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LibraryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "BookISBN", "dbo.Book");
            DropIndex("dbo.Review", new[] { "BookISBN" });
            DropTable("dbo.Library");
            DropTable("dbo.Review");
            DropTable("dbo.Book");
            DropTable("dbo.BookList");
        }
    }
}
