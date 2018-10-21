namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookClubDb : DbMigration
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
                        AdminEmail = c.String(nullable: false),
                        Profile = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Province = c.String(nullable: false),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookClub", "BookClub_BookClubID", "dbo.BookClub");
            DropForeignKey("dbo.BookClubMember", "BookClubMember_MemberID", "dbo.BookClubMember");
            DropIndex("dbo.BookClub", new[] { "BookClub_BookClubID" });
            DropIndex("dbo.BookClubMember", new[] { "BookClubMember_MemberID" });
            DropTable("dbo.BookClub");
            DropTable("dbo.BookClubMember");
        }
    }
}
