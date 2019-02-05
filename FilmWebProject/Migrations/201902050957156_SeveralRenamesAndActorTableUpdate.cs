namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeveralRenamesAndActorTableUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Casts", newName: "Actors");
            RenameTable(name: "dbo.FilmCasts", newName: "FilmActors");
            RenameColumn(table: "dbo.FilmActors", name: "Cast_Id", newName: "Actor_Id");
            RenameColumn(table: "dbo.Rewards", name: "Cast_Id", newName: "Actor_Id");
            RenameIndex(table: "dbo.Rewards", name: "IX_Cast_Id", newName: "IX_Actor_Id");
            RenameIndex(table: "dbo.FilmActors", name: "IX_Cast_Id", newName: "IX_Actor_Id");
            AddColumn("dbo.Rewards", "Composer_Id", c => c.Int());
            AddColumn("dbo.Composers", "FirstName", c => c.String());
            AddColumn("dbo.Composers", "LastName", c => c.String());
            AddColumn("dbo.Composers", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.Composers", "PlaceOfBirth", c => c.String());
            AddColumn("dbo.Composers", "Height", c => c.Int(nullable: false));
            AddColumn("dbo.Composers", "ProfilePhoto", c => c.Binary());
            AddColumn("dbo.Composers", "Biography", c => c.String());
            AddColumn("dbo.Composers", "Score", c => c.Double(nullable: false));
            CreateIndex("dbo.Rewards", "Composer_Id");
            AddForeignKey("dbo.Rewards", "Composer_Id", "dbo.Composers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rewards", "Composer_Id", "dbo.Composers");
            DropIndex("dbo.Rewards", new[] { "Composer_Id" });
            DropColumn("dbo.Composers", "Score");
            DropColumn("dbo.Composers", "Biography");
            DropColumn("dbo.Composers", "ProfilePhoto");
            DropColumn("dbo.Composers", "Height");
            DropColumn("dbo.Composers", "PlaceOfBirth");
            DropColumn("dbo.Composers", "DateOfBirth");
            DropColumn("dbo.Composers", "LastName");
            DropColumn("dbo.Composers", "FirstName");
            DropColumn("dbo.Rewards", "Composer_Id");
            RenameIndex(table: "dbo.FilmActors", name: "IX_Actor_Id", newName: "IX_Cast_Id");
            RenameIndex(table: "dbo.Rewards", name: "IX_Actor_Id", newName: "IX_Cast_Id");
            RenameColumn(table: "dbo.Rewards", name: "Actor_Id", newName: "Cast_Id");
            RenameColumn(table: "dbo.FilmActors", name: "Actor_Id", newName: "Cast_Id");
            RenameTable(name: "dbo.FilmActors", newName: "FilmCasts");
            RenameTable(name: "dbo.Actors", newName: "Casts");
        }
    }
}
