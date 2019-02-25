namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateOfPublicationForReviewNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "DateOfPublication", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "DateOfPublication", c => c.DateTime(nullable: false));
        }
    }
}
