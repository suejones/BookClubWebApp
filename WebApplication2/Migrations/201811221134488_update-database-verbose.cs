namespace WebApplication2
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedatabaseverbose : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookClubMember",
                c => new
                    {
                        MemberID = c.Int(nullable: false, identity: true),
                        MemberFirstName = c.String(nullable: false, maxLength: 55),
                        MemberLastName = c.String(nullable: false, maxLength: 55),
                        MemberEmail = c.String(nullable: false),
                        BookClubMember_MemberID = c.Int(),
                    })
                .PrimaryKey(t => t.MemberID)
                .ForeignKey("dbo.BookClubMember", t => t.BookClubMember_MemberID)
                .Index(t => t.BookClubMember_MemberID);
            
            CreateTable(
                "dbo.BookClub",
                c => new
                    {
                        BookClubID = c.Int(nullable: false, identity: true),
                        BookClubName = c.String(nullable: false, maxLength: 55),
                        AdminEmail = c.String(nullable: false, maxLength: 55),
                        Profile = c.String(nullable: false, maxLength: 250),
                        Status = c.Int(nullable: false),
                        Province = c.Int(nullable: false),
                        County = c.String(nullable: false),
                        Area = c.String(nullable: false),
                        LibraryName = c.String(nullable: false),
                        NextMeeting = c.String(nullable: false),
                        CurrentRead = c.String(nullable: false),
                        BookClub_BookClubID = c.Int(),
                    })
                .PrimaryKey(t => t.BookClubID)
                .ForeignKey("dbo.BookClub", t => t.BookClub_BookClubID)
                .Index(t => t.BookClub_BookClubID);
            
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
                        BookTitle = c.String(nullable: false, maxLength: 55),
                        AuthorName = c.String(nullable: false, maxLength: 55),
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
            DropForeignKey("dbo.BookClub", "BookClub_BookClubID", "dbo.BookClub");
            DropForeignKey("dbo.BookClubMember", "BookClubMember_MemberID", "dbo.BookClubMember");
            DropIndex("dbo.Review", new[] { "BookISBN" });
            DropIndex("dbo.BookClub", new[] { "BookClub_BookClubID" });
            DropIndex("dbo.BookClubMember", new[] { "BookClubMember_MemberID" });
            DropTable("dbo.Library");
            DropTable("dbo.Review");
            DropTable("dbo.Book");
            DropTable("dbo.BookList");
            DropTable("dbo.BookClub");
            DropTable("dbo.BookClubMember");
        }
    }
}
