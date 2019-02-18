namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReviews : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        DateOfPublication = c.DateTime(nullable: false),
                        Content = c.String(),
                        Author_Id = c.String(maxLength: 128),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Film_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Reviews", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "Film_Id" });
            DropIndex("dbo.Reviews", new[] { "Author_Id" });
            DropTable("dbo.Reviews");
        }
    }
}
