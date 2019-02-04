namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullableDatetimeAcorssDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Reviews", "FilmId", "dbo.Films");
            DropIndex("dbo.Reviews", new[] { "FilmId" });
            RenameColumn(table: "dbo.Reviews", name: "FilmId", newName: "ReviewedFilm_Id");
            AlterColumn("dbo.Casts", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Directors", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Photographers", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Reviews", "DateOfPublication", c => c.DateTime());
            AlterColumn("dbo.Reviews", "ReviewedFilm_Id", c => c.Int());
            AlterColumn("dbo.Scriptwriters", "DateOfBirth", c => c.DateTime());
            CreateIndex("dbo.Reviews", "ReviewedFilm_Id");
            AddForeignKey("dbo.Reviews", "ReviewedFilm_Id", "dbo.Films", "Id");
            DropColumn("dbo.Reviews", "AuthorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "AuthorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Reviews", "ReviewedFilm_Id", "dbo.Films");
            DropIndex("dbo.Reviews", new[] { "ReviewedFilm_Id" });
            AlterColumn("dbo.Scriptwriters", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Reviews", "ReviewedFilm_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "DateOfPublication", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Photographers", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Directors", "DateOfBirth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Casts", "DateOfBirth", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Reviews", name: "ReviewedFilm_Id", newName: "FilmId");
            CreateIndex("dbo.Reviews", "FilmId");
            AddForeignKey("dbo.Reviews", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
        }
    }
}
