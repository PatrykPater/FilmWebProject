namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDatetimeType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Release", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Release", c => c.DateTime());
        }
    }
}
