namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyGenreIdOForFilm : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Films", new[] { "Genre_Id" });
            RenameColumn(table: "dbo.Films", name: "Genre_Id", newName: "GenreId");
            AlterColumn("dbo.Films", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "GenreId");
            AddForeignKey("dbo.Films", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropIndex("dbo.Films", new[] { "GenreId" });
            AlterColumn("dbo.Films", "GenreId", c => c.Int());
            RenameColumn(table: "dbo.Films", name: "GenreId", newName: "Genre_Id");
            CreateIndex("dbo.Films", "Genre_Id");
            AddForeignKey("dbo.Films", "Genre_Id", "dbo.Genres", "Id");
        }
    }
}
