namespace WebApplication2
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bclubandbcmemberchanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BookClubMember", "BookClub_BookClubID", c => c.Int());
            AddColumn("dbo.BookClub", "BookClubMember_MemberID", c => c.Int());
            CreateIndex("dbo.BookClubMember", "BookClub_BookClubID");
            CreateIndex("dbo.BookClub", "BookClubMember_MemberID");
            AddForeignKey("dbo.BookClubMember", "BookClub_BookClubID", "dbo.BookClub", "BookClubID");
            AddForeignKey("dbo.BookClub", "BookClubMember_MemberID", "dbo.BookClubMember", "MemberID");
            DropColumn("dbo.BookClub", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookClub", "Status", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookClub", "BookClubMember_MemberID", "dbo.BookClubMember");
            DropForeignKey("dbo.BookClubMember", "BookClub_BookClubID", "dbo.BookClub");
            DropIndex("dbo.BookClub", new[] { "BookClubMember_MemberID" });
            DropIndex("dbo.BookClubMember", new[] { "BookClub_BookClubID" });
            DropColumn("dbo.BookClub", "BookClubMember_MemberID");
            DropColumn("dbo.BookClubMember", "BookClub_BookClubID");
        }
    }
}
