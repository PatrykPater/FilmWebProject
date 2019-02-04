namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BoxOffice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Films", "BoxOffice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Films", "BoxOffice");
        }
    }
}
