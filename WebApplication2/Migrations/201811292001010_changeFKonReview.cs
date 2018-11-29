namespace WebApplication2
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeFKonReview : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "Book_BookISBN", "dbo.Book");
            DropIndex("dbo.Review", new[] { "Book_BookISBN" });
            RenameColumn(table: "dbo.Review", name: "Book_BookISBN", newName: "BookISBN");
            AlterColumn("dbo.Review", "BookISBN", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "BookISBN");
            AddForeignKey("dbo.Review", "BookISBN", "dbo.Book", "BookISBN", cascadeDelete: true);
            DropColumn("dbo.Review", "BookTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "BookTitle", c => c.Int(nullable: false));
            DropForeignKey("dbo.Review", "BookISBN", "dbo.Book");
            DropIndex("dbo.Review", new[] { "BookISBN" });
            AlterColumn("dbo.Review", "BookISBN", c => c.Int());
            RenameColumn(table: "dbo.Review", name: "BookISBN", newName: "Book_BookISBN");
            CreateIndex("dbo.Review", "Book_BookISBN");
            AddForeignKey("dbo.Review", "Book_BookISBN", "dbo.Book", "BookISBN");
        }
    }
}
