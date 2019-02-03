namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveStudioAndFillMissingFields : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Actors", newName: "Casts");
            RenameTable(name: "dbo.FilmActors", newName: "FilmCasts");
            DropForeignKey("dbo.Films", "Studio_Id", "dbo.Studios");
            DropForeignKey("dbo.Films", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Films", "Music_Id", "dbo.Composers");
            DropForeignKey("dbo.Reviews", "Film_Id", "dbo.Films");
            DropIndex("dbo.Films", new[] { "Genre_Id" });
            DropIndex("dbo.Films", new[] { "Music_Id" });
            DropIndex("dbo.Films", new[] { "Studio_Id" });
            DropIndex("dbo.Reviews", new[] { "Film_Id" });
            RenameColumn(table: "dbo.FilmCasts", name: "Actor_Id", newName: "Cast_Id");
            RenameColumn(table: "dbo.Films", name: "Genre_Id", newName: "GenreId");
            RenameColumn(table: "dbo.Films", name: "Music_Id", newName: "ComposerId");
            RenameColumn(table: "dbo.Reviews", name: "Film_Id", newName: "FilmId");
            RenameColumn(table: "dbo.Rewards", name: "Actor_Id", newName: "Cast_Id");
            RenameIndex(table: "dbo.Rewards", name: "IX_Actor_Id", newName: "IX_Cast_Id");
            RenameIndex(table: "dbo.FilmCasts", name: "IX_Actor_Id", newName: "IX_Cast_Id");
            AddColumn("dbo.Films", "Studio", c => c.String());
            AddColumn("dbo.Rewards", "Name", c => c.String());
            AddColumn("dbo.Rewards", "Category", c => c.String());
            AddColumn("dbo.Rewards", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.Genres", "Name", c => c.String());
            AddColumn("dbo.Reviews", "Title", c => c.String());
            AddColumn("dbo.Reviews", "DateOfPublication", c => c.DateTime(nullable: false));
            AddColumn("dbo.Reviews", "Content", c => c.String());
            AddColumn("dbo.Reviews", "Score", c => c.Double(nullable: false));
            AddColumn("dbo.Reviews", "AuthorId", c => c.Int(nullable: false));
            AddColumn("dbo.Reviews", "Author_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Trailers", "LinkToTrailer", c => c.String());
            AlterColumn("dbo.Films", "GenreId", c => c.Int(nullable: false));
            AlterColumn("dbo.Films", "ComposerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Reviews", "FilmId", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "GenreId");
            CreateIndex("dbo.Films", "ComposerId");
            CreateIndex("dbo.Reviews", "FilmId");
            CreateIndex("dbo.Reviews", "Author_Id");
            AddForeignKey("dbo.Reviews", "Author_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Films", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Films", "ComposerId", "dbo.Composers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Reviews", "FilmId", "dbo.Films", "Id", cascadeDelete: true);
            DropColumn("dbo.Films", "Studio_Id");
            DropTable("dbo.Studios");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Films", "Studio_Id", c => c.Int());
            DropForeignKey("dbo.Reviews", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Films", "ComposerId", "dbo.Composers");
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Reviews", "Author_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Reviews", new[] { "Author_Id" });
            DropIndex("dbo.Reviews", new[] { "FilmId" });
            DropIndex("dbo.Films", new[] { "ComposerId" });
            DropIndex("dbo.Films", new[] { "GenreId" });
            AlterColumn("dbo.Reviews", "FilmId", c => c.Int());
            AlterColumn("dbo.Films", "ComposerId", c => c.Int());
            AlterColumn("dbo.Films", "GenreId", c => c.Int());
            DropColumn("dbo.Trailers", "LinkToTrailer");
            DropColumn("dbo.Reviews", "Author_Id");
            DropColumn("dbo.Reviews", "AuthorId");
            DropColumn("dbo.Reviews", "Score");
            DropColumn("dbo.Reviews", "Content");
            DropColumn("dbo.Reviews", "DateOfPublication");
            DropColumn("dbo.Reviews", "Title");
            DropColumn("dbo.Genres", "Name");
            DropColumn("dbo.Rewards", "Year");
            DropColumn("dbo.Rewards", "Category");
            DropColumn("dbo.Rewards", "Name");
            DropColumn("dbo.Films", "Studio");
            RenameIndex(table: "dbo.FilmCasts", name: "IX_Cast_Id", newName: "IX_Actor_Id");
            RenameIndex(table: "dbo.Rewards", name: "IX_Cast_Id", newName: "IX_Actor_Id");
            RenameColumn(table: "dbo.Rewards", name: "Cast_Id", newName: "Actor_Id");
            RenameColumn(table: "dbo.Reviews", name: "FilmId", newName: "Film_Id");
            RenameColumn(table: "dbo.Films", name: "ComposerId", newName: "Music_Id");
            RenameColumn(table: "dbo.Films", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.FilmCasts", name: "Cast_Id", newName: "Actor_Id");
            CreateIndex("dbo.Reviews", "Film_Id");
            CreateIndex("dbo.Films", "Studio_Id");
            CreateIndex("dbo.Films", "Music_Id");
            CreateIndex("dbo.Films", "Genre_Id");
            AddForeignKey("dbo.Reviews", "Film_Id", "dbo.Films", "Id");
            AddForeignKey("dbo.Films", "Music_Id", "dbo.Composers", "Id");
            AddForeignKey("dbo.Films", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Films", "Studio_Id", "dbo.Studios", "Id");
            RenameTable(name: "dbo.FilmCasts", newName: "FilmActors");
            RenameTable(name: "dbo.Casts", newName: "Actors");
        }
    }
}
