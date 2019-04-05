namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeNullableDateTimeTypeReview : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Reviews", "DateOfPublication", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Reviews", "DateOfPublication", c => c.DateTime());
        }
    }
}
