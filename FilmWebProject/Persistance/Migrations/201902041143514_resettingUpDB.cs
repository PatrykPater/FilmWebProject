using System.Data.Entity.Migrations;

namespace FilmWebProject.Persistance.Migrations
{
    public partial class resettingUpDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Casts",
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
                        Release = c.DateTime(),
                        Budget = c.Double(nullable: false),
                        Score = c.Double(nullable: false),
                        Studio = c.String(),
                        BoxOffice = c.Double(nullable: false),
                        GenreId = c.Int(nullable: false),
                        Director_Id = c.Int(),
                        Music_Id = c.Int(),
                        Photography_Id = c.Int(),
                        Scriptwriter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .ForeignKey("dbo.Composers", t => t.Music_Id)
                .ForeignKey("dbo.Photographers", t => t.Photography_Id)
                .ForeignKey("dbo.Scriptwriters", t => t.Scriptwriter_Id)
                .Index(t => t.GenreId)
                .Index(t => t.Director_Id)
                .Index(t => t.Music_Id)
                .Index(t => t.Photography_Id)
                .Index(t => t.Scriptwriter_Id);
            
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
                        Name = c.String(),
                        Category = c.String(),
                        Year = c.Int(nullable: false),
                        Director_Id = c.Int(),
                        Photographer_Id = c.Int(),
                        Film_Id = c.Int(),
                        Scriptwriter_Id = c.Int(),
                        Cast_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Directors", t => t.Director_Id)
                .ForeignKey("dbo.Photographers", t => t.Photographer_Id)
                .ForeignKey("dbo.Films", t => t.Film_Id)
                .ForeignKey("dbo.Scriptwriters", t => t.Scriptwriter_Id)
                .ForeignKey("dbo.Casts", t => t.Cast_Id)
                .Index(t => t.Director_Id)
                .Index(t => t.Photographer_Id)
                .Index(t => t.Film_Id)
                .Index(t => t.Scriptwriter_Id)
                .Index(t => t.Cast_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                        Title = c.String(),
                        DateOfPublication = c.DateTime(nullable: false),
                        Content = c.String(),
                        Score = c.Double(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        Author_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Trailers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LinkToTrailer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FilmCasts",
                c => new
                    {
                        Film_Id = c.Int(nullable: false),
                        Cast_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Film_Id, t.Cast_Id })
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.Casts", t => t.Cast_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.Cast_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Rewards", "Cast_Id", "dbo.Casts");
            DropForeignKey("dbo.Rewards", "Scriptwriter_Id", "dbo.Scriptwriters");
            DropForeignKey("dbo.Films", "Scriptwriter_Id", "dbo.Scriptwriters");
            DropForeignKey("dbo.Rewards", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Reviews", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Reviews", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rewards", "Photographer_Id", "dbo.Photographers");
            DropForeignKey("dbo.Films", "Photography_Id", "dbo.Photographers");
            DropForeignKey("dbo.Films", "Music_Id", "dbo.Composers");
            DropForeignKey("dbo.Films", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Rewards", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.Films", "Director_Id", "dbo.Directors");
            DropForeignKey("dbo.FilmCasts", "Cast_Id", "dbo.Casts");
            DropForeignKey("dbo.FilmCasts", "Film_Id", "dbo.Films");
            DropIndex("dbo.FilmCasts", new[] { "Cast_Id" });
            DropIndex("dbo.FilmCasts", new[] { "Film_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Reviews", new[] { "Author_Id" });
            DropIndex("dbo.Reviews", new[] { "FilmId" });
            DropIndex("dbo.Rewards", new[] { "Cast_Id" });
            DropIndex("dbo.Rewards", new[] { "Scriptwriter_Id" });
            DropIndex("dbo.Rewards", new[] { "Film_Id" });
            DropIndex("dbo.Rewards", new[] { "Photographer_Id" });
            DropIndex("dbo.Rewards", new[] { "Director_Id" });
            DropIndex("dbo.Films", new[] { "Scriptwriter_Id" });
            DropIndex("dbo.Films", new[] { "Photography_Id" });
            DropIndex("dbo.Films", new[] { "Music_Id" });
            DropIndex("dbo.Films", new[] { "Director_Id" });
            DropIndex("dbo.Films", new[] { "GenreId" });
            DropTable("dbo.FilmCasts");
            DropTable("dbo.Trailers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Scriptwriters");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Photographers");
            DropTable("dbo.Composers");
            DropTable("dbo.Genres");
            DropTable("dbo.Rewards");
            DropTable("dbo.Directors");
            DropTable("dbo.Films");
            DropTable("dbo.Casts");
        }
    }
}
