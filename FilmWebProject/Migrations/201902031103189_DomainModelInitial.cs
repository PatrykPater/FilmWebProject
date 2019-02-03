namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DomainModelInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(),
                        Height = c.Int(nullable: false),
                        ProfilePhoto = c.Binary(),
                        Biography = c.String(),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Duration = c.Time(nullable: false, precision: 7),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Production = c.String(),
                        Release = c.DateTime(nullable: false),
                        Budget = c.Double(nullable: false),
                        Score = c.Double(nullable: false),
                        Director_Id = c.Int(),
                        Genre_Id = c.Int(),
                        Music_Id = c.Int(),
                        Photography_Id = c.Int(),
                        Scriptwriter_Id = c.Int(),
                        Studio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Composers", t => t.Music_Id)
                .ForeignKey("dbo.Photographers", t => t.Photography_Id)
                .ForeignKey("dbo.Scriptwriters", t => t.Scriptwriter_Id)
                .ForeignKey("dbo.Studios", t => t.Studio_Id)
                .Index(t => t.Director_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Music_Id)
                .Index(t => t.Photography_Id)
                .Index(t => t.Scriptwriter_Id)
                .Index(t => t.Studio_Id);
            
            CreateTable(
                "dbo.Directors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(),
                        Height = c.Int(nullable: false),
                        ProfilePhoto = c.Binary(),
                        Biography = c.String(),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rewards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Director_Id = c.Int(),
                        Photographer_Id = c.Int(),
                        Film_Id = c.Int(),
                        Scriptwriter_Id = c.Int(),
                        Actor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id)
                .ForeignKey("dbo.Films", t => t.Film_Id)
                .ForeignKey("dbo.Scriptwriters", t => t.Scriptwriter_Id)
                .ForeignKey("dbo.Actors", t => t.Actor_Id)
                .Index(t => t.Director_Id)
                .Index(t => t.Photographer_Id)
                .Index(t => t.Film_Id)
                .Index(t => t.Scriptwriter_Id)
                .Index(t => t.Actor_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Composers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Photographers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(),
                        Height = c.Int(nullable: false),
                        ProfilePhoto = c.Binary(),
                        Biography = c.String(),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Film_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id)
                .Index(t => t.Film_Id);
            
            CreateTable(
                "dbo.Scriptwriters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(),
                        Height = c.Int(nullable: false),
                        ProfilePhoto = c.Binary(),
                        Biography = c.String(),
                        Score = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trailers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmActors",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Actor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Actor_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Actor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rewards", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.Films", "Studio_Id", "dbo.Studios");
            DropForeignKey("dbo.Rewards", "Scriptwriter_Id", "dbo.Scriptwriters");
            DropForeignKey("dbo.Films", "Scriptwriter_Id", "dbo.Scriptwriters");
            DropForeignKey("dbo.Rewards", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Reviews", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Rewards", "Photographer_Id", "dbo.Photographers");
            DropForeignKey("dbo.Films", "Photography_Id", "dbo.Photographers");
            DropForeignKey("dbo.Films", "Music_Id", "dbo.Composers");
            DropForeignKey("dbo.Films", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.Rewards", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.Films", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.FilmActors", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.FilmActors", "Film_Id", "dbo.Films");
            DropIndex("dbo.FilmActors", new[] { "Actor_Id" });
            DropIndex("dbo.FilmActors", new[] { "Film_Id" });
            DropIndex("dbo.Reviews", new[] { "Film_Id" });
            DropIndex("dbo.Rewards", new[] { "Actor_Id" });
            DropIndex("dbo.Rewards", new[] { "Scriptwriter_Id" });
            DropIndex("dbo.Rewards", new[] { "Film_Id" });
            DropIndex("dbo.Rewards", new[] { "Photographer_Id" });
            DropIndex("dbo.Rewards", new[] { "Director_Id" });
            DropIndex("dbo.Films", new[] { "Studio_Id" });
            DropIndex("dbo.Films", new[] { "Scriptwriter_Id" });
            DropIndex("dbo.Films", new[] { "Photography_Id" });
            DropIndex("dbo.Films", new[] { "Music_Id" });
            DropIndex("dbo.Films", new[] { "Genre_Id" });
            DropIndex("dbo.Films", new[] { "Director_Id" });
            DropTable("dbo.FilmActors");
            DropTable("dbo.Trailers");
            DropTable("dbo.Studios");
            DropTable("dbo.Scriptwriters");
            DropTable("dbo.Reviews");
            DropTable("dbo.Photographers");
            DropTable("dbo.Composers");
            DropTable("dbo.Genres");
            DropTable("dbo.Rewards");
            DropTable("dbo.Directors");
            DropTable("dbo.Films");
            DropTable("dbo.Actors");
        }
    }
}
