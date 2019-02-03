namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThrillerGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Name) VALUES ('Thriller')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Genres WHERE Name IN ('Thriller')");
        }
    }
}
