namespace FilmWebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameCinematographers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Photographers", newName: "Cinematographers");
            RenameColumn(table: "dbo.Films", name: "Photography_Id", newName: "Cinematography_Id");
            RenameColumn(table: "dbo.Rewards", name: "Photographer_Id", newName: "Cinematographer_Id");
            RenameIndex(table: "dbo.Films", name: "IX_Photography_Id", newName: "IX_Cinematography_Id");
            RenameIndex(table: "dbo.Rewards", name: "IX_Photographer_Id", newName: "IX_Cinematographer_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Rewards", name: "IX_Cinematographer_Id", newName: "IX_Photographer_Id");
            RenameIndex(table: "dbo.Films", name: "IX_Cinematography_Id", newName: "IX_Photography_Id");
            RenameColumn(table: "dbo.Rewards", name: "Cinematographer_Id", newName: "Photographer_Id");
            RenameColumn(table: "dbo.Films", name: "Cinematography_Id", newName: "Photography_Id");
            RenameTable(name: "dbo.Cinematographers", newName: "Photographers");
        }
    }
}
