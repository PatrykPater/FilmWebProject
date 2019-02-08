namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DBTest : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropIndex("dbo.Films", new[] { "GenreId" });
            AlterColumn("dbo.Films", "GenreId", c => c.Int());
            CreateIndex("dbo.Films", "GenreId");
            AddForeignKey("dbo.Films", "GenreId", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropIndex("dbo.Films", new[] { "GenreId" });
            AlterColumn("dbo.Films", "GenreId", c => c.Int(nullable: false));
            CreateIndex("dbo.Films", "GenreId");
            AddForeignKey("dbo.Films", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
