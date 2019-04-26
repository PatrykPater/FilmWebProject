namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateOfPublicationForReview : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reviews", "DateOfPublication");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "DateOfPublication", c => c.DateTime(nullable: false));
        }
    }
}
