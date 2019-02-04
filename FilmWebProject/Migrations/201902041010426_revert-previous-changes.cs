namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class revertpreviouschanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Release", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Release", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
    }
}
