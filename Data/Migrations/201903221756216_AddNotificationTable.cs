namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotificationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Recipient_Id = c.String(nullable: false, maxLength: 128),
                        Sender_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Recipient_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Sender_Id)
                .Index(t => t.Recipient_Id)
                .Index(t => t.Sender_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notifications", "Sender_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Notifications", "Recipient_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Notifications", new[] { "Sender_Id" });
            DropIndex("dbo.Notifications", new[] { "Recipient_Id" });
            DropTable("dbo.Notifications");
        }
    }
}
