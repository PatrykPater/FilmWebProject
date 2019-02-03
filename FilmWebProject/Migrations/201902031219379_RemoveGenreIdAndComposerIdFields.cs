namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGenreIdAndComposerIdFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Films", "ComposerId", "dbo.Composers");
            DropIndex("dbo.Films", new[] { "GenreId" });
            DropIndex("dbo.Films", new[] { "ComposerId" });
            RenameColumn(table: "dbo.Films", name: "GenreId", newName: "Genre_Id");
            RenameColumn(table: "dbo.Films", name: "ComposerId", newName: "Music_Id");
            AlterColumn("dbo.Films", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Films", "Music_Id", c => c.Int());
            CreateIndex("dbo.Films", "Genre_Id");
            CreateIndex("dbo.Films", "Music_Id");
            AddForeignKey("dbo.Films", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.Films", "Music_Id", "dbo.Composers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Films", "Music_Id", "dbo.Composers");
            DropForeignKey("dbo.Films", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.Films", new[] { "Music_Id" });
            DropIndex("dbo.Films", new[] { "Genre_Id" });
            AlterColumn("dbo.Films", "Music_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Films", "Genre_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Films", name: "Music_Id", newName: "ComposerId");
            RenameColumn(table: "dbo.Films", name: "Genre_Id", newName: "GenreId");
            CreateIndex("dbo.Films", "ComposerId");
            CreateIndex("dbo.Films", "GenreId");
            AddForeignKey("dbo.Films", "ComposerId", "dbo.Composers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Films", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}
