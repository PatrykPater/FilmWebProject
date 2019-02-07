namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameStars : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Actors", newName: "Stars");
            RenameTable(name: "dbo.FilmActors", newName: "FilmStars");
            RenameColumn(table: "dbo.FilmStars", name: "Actor_Id", newName: "Star_Id");
            RenameColumn(table: "dbo.Rewards", name: "Actor_Id", newName: "Star_Id");
            RenameIndex(table: "dbo.Rewards", name: "IX_Actor_Id", newName: "IX_Star_Id");
            RenameIndex(table: "dbo.FilmStars", name: "IX_Actor_Id", newName: "IX_Star_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.FilmStars", name: "IX_Star_Id", newName: "IX_Actor_Id");
            RenameIndex(table: "dbo.Rewards", name: "IX_Star_Id", newName: "IX_Actor_Id");
            RenameColumn(table: "dbo.Rewards", name: "Star_Id", newName: "Actor_Id");
            RenameColumn(table: "dbo.FilmStars", name: "Star_Id", newName: "Actor_Id");
            RenameTable(name: "dbo.FilmStars", newName: "FilmActors");
            RenameTable(name: "dbo.Stars", newName: "Actors");
        }
    }
}
