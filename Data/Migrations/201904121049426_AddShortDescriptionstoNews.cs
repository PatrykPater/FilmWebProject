namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShortDescriptionstoNews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "ShortDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "ShortDescription");
        }
    }
}
