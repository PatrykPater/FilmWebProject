using System.Data.Entity.Migrations;

namespace FilmWebProject.Migrations
{
    public partial class changeReleaseDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Films", "Release", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Films", "Release", c => c.String());
        }
    }
}
