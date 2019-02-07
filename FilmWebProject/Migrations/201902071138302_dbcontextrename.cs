namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbcontextrename : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.FilmStars", newName: "StarFilms");
            DropPrimaryKey("dbo.StarFilms");
            AddPrimaryKey("dbo.StarFilms", new[] { "Star_Id", "Film_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.StarFilms");
            AddPrimaryKey("dbo.StarFilms", new[] { "Film_Id", "Star_Id" });
            RenameTable(name: "dbo.StarFilms", newName: "FilmStars");
        }
    }
}
