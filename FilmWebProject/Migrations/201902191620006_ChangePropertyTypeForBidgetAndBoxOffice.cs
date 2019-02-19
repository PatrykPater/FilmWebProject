namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePropertyTypeForBidgetAndBoxOffice : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Budget", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Films", "BoxOffice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "BoxOffice", c => c.Double(nullable: false));
            AlterColumn("dbo.Films", "Budget", c => c.Double(nullable: false));
        }
    }
}
