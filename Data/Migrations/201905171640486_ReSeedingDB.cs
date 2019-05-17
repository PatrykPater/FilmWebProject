namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReSeedingDB : DbMigration
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
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
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
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        Film_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Films", t => t.Film_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Film_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
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
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.ApplicationUser_Id);
            
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
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Content = c.String(),
                        ShortDescription = c.String(),
                        DateOfPublication = c.DateTime(nullable: false),
                        Author_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Author_Id, cascadeDelete: true)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.NewsTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsRead = c.Boolean(nullable: false),
                        NotificationType = c.Int(nullable: false),
                        Recipient_Id = c.String(nullable: false, maxLength: 128),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Recipient_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.Recipient_Id)
                .Index(t => t.Sender_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 75),
                        DateOfPublication = c.DateTime(nullable: false),
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
                "dbo.NewsAndNewsTags",
                c => new
                    {
                        NewsRefId = c.Int(nullable: false),
                        TypeRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NewsRefId, t.TypeRefId })
                .ForeignKey("dbo.News", t => t.NewsRefId, cascadeDelete: true)
                .ForeignKey("dbo.NewsTags", t => t.TypeRefId, cascadeDelete: true)
                .Index(t => t.NewsRefId)
                .Index(t => t.TypeRefId);
            
            CreateTable(
                "dbo.FilmCountry",
                c => new
                    {
                        FilmRefId = c.Int(nullable: false),
                        CountryRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FilmRefId, t.CountryRefId })
                .ForeignKey("dbo.Countries", t => t.FilmRefId, cascadeDelete: true)
                .ForeignKey("dbo.Films", t => t.CountryRefId, cascadeDelete: true)
                .Index(t => t.FilmRefId)
                .Index(t => t.CountryRefId);
            
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
            DropForeignKey("dbo.FilmCountry", "CountryRefId", "dbo.Films");
            DropForeignKey("dbo.FilmCountry", "FilmRefId", "dbo.Countries");
            DropForeignKey("dbo.Trailers", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reviews", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.Reviews", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Recipient_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.NewsAndNewsTags", "TypeRefId", "dbo.NewsTags");
            DropForeignKey("dbo.NewsAndNewsTags", "NewsRefId", "dbo.News");
            DropForeignKey("dbo.News", "Author_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Ratings", "Film_Id", "dbo.Films");
            DropForeignKey("dbo.FilmGenre", "GenreRefId", "dbo.Genres");
            DropForeignKey("dbo.FilmGenre", "FilmRefId", "dbo.Films");
            DropIndex("dbo.PersonJob", new[] { "JobRefId" });
            DropIndex("dbo.PersonJob", new[] { "PersonRefId" });
            DropIndex("dbo.FilmCountry", new[] { "CountryRefId" });
            DropIndex("dbo.FilmCountry", new[] { "FilmRefId" });
            DropIndex("dbo.NewsAndNewsTags", new[] { "TypeRefId" });
            DropIndex("dbo.NewsAndNewsTags", new[] { "NewsRefId" });
            DropIndex("dbo.FilmGenre", new[] { "GenreRefId" });
            DropIndex("dbo.FilmGenre", new[] { "FilmRefId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Nominations", new[] { "FilmId" });
            DropIndex("dbo.Nominations", new[] { "AwardId" });
            DropIndex("dbo.Trailers", new[] { "Film_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.Reviews", new[] { "Film_Id" });
            DropIndex("dbo.Reviews", new[] { "Author_Id" });
            DropIndex("dbo.Notifications", new[] { "Sender_Id" });
            DropIndex("dbo.Notifications", new[] { "Recipient_Id" });
            DropIndex("dbo.News", new[] { "Author_Id" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Ratings", new[] { "User_Id" });
            DropIndex("dbo.Ratings", new[] { "Film_Id" });
            DropTable("dbo.PersonJob");
            DropTable("dbo.FilmCountry");
            DropTable("dbo.NewsAndNewsTags");
            DropTable("dbo.FilmGenre");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Nominations");
            DropTable("dbo.People");
            DropTable("dbo.Jobs");
            DropTable("dbo.Trailers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.Reviews");
            DropTable("dbo.Notifications");
            DropTable("dbo.NewsTags");
            DropTable("dbo.News");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Ratings");
            DropTable("dbo.Genres");
            DropTable("dbo.Films");
            DropTable("dbo.Countries");
            DropTable("dbo.Awards");
        }
    }
}
