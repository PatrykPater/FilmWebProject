namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDuplicateUserIdColumn : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Awards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Category = c.String(nullable: false, maxLength: 100),
                        Year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Films",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 50),
                        Duration = c.Time(nullable: false, precision: 7),
                        ShortDescription = c.String(),
                        LongDescription = c.String(),
                        Production = c.String(),
                        Release = c.DateTime(nullable: false),
                        Budget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Studio = c.String(),
                        BoxOffice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 75),
                        DateOfPublication = c.DateTime(),
                        Content = c.String(),
                        Author_Id = c.String(nullable: false, maxLength: 128),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Author_Id)
                .Index(t => t.Film_Id);
            
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
                "dbo.Ratings",
                c => new
                    {
                        ScoreId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ScoreId, t.UserId })
                .ForeignKey("dbo.Scores", t => t.ScoreId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ScoreId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Scores",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Id)
                .Index(t => t.Id);
            
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
                "dbo.Trailers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrailerLink = c.String(nullable: false, maxLength: 300),
                        Film_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .Index(t => t.Film_Id);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(),
                        Height = c.Int(nullable: false),
                        ProfilePhoto = c.Binary(),
                        Biography = c.String(),
                        Score = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nominations",
                c => new
                    {
                        AwardId = c.Int(nullable: false),
                        FilmId = c.Int(nullable: false),
                        HasWon = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.AwardId, t.FilmId })
                .ForeignKey("dbo.Awards", t => t.AwardId, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.AwardId)
                .Index(t => t.FilmId);
            
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
                "dbo.FilmGenre",
                c => new
                    {
                        FilmRefId = c.Int(nullable: false),
                        GenreRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilmRefId, t.GenreRefId })
                .ForeignKey("dbo.Films", t => t.FilmRefId, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.GenreRefId, cascadeDelete: true)
                .Index(t => t.FilmRefId)
                .Index(t => t.GenreRefId);
            
            CreateTable(
                "dbo.PersonJob",
                c => new
                    {
                        PersonRefId = c.Int(nullable: false),
                        JobRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonRefId, t.JobRefId })
                .ForeignKey("dbo.People", t => t.PersonRefId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.JobRefId, cascadeDelete: true)
                .Index(t => t.PersonRefId)
                .Index(t => t.JobRefId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Nominations", "FilmId", "dbo.Films");
            DropForeignKey("dbo.Nominations", "AwardId", "dbo.Awards");
            DropForeignKey("dbo.PersonJob", "JobRefId", "dbo.Jobs");
            DropForeignKey("dbo.PersonJob", "PersonRefId", "dbo.People");
            DropForeignKey("dbo.Trailers", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Scores", "Id", "dbo.Films");
            DropForeignKey("dbo.Reviews", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Reviews", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "ScoreId", "dbo.Scores");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.FilmGenre", "GenreRefId", "dbo.Genres");
            DropForeignKey("dbo.FilmGenre", "FilmRefId", "dbo.Films");
            DropIndex("dbo.PersonJob", new[] { "JobRefId" });
            DropIndex("dbo.PersonJob", new[] { "PersonRefId" });
            DropIndex("dbo.FilmGenre", new[] { "GenreRefId" });
            DropIndex("dbo.FilmGenre", new[] { "FilmRefId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Nominations", new[] { "FilmId" });
            DropIndex("dbo.Nominations", new[] { "AwardId" });
            DropIndex("dbo.Trailers", new[] { "Film_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Scores", new[] { "Id" });
            DropIndex("dbo.Ratings", new[] { "UserId" });
            DropIndex("dbo.Ratings", new[] { "ScoreId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Reviews", new[] { "Film_Id" });
            DropIndex("dbo.Reviews", new[] { "Author_Id" });
            DropTable("dbo.PersonJob");
            DropTable("dbo.FilmGenre");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Nominations");
            DropTable("dbo.People");
            DropTable("dbo.Jobs");
            DropTable("dbo.Trailers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Scores");
            DropTable("dbo.Ratings");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Reviews");
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
            DropTable("dbo.Awards");
        }
    }
}
