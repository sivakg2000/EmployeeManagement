namespace UserInfoManager.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class DroppedTaxOffId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "TaxOffice_Id", "dbo.TaxOffices");
            DropIndex("dbo.Users", new[] { "TaxOffice_Id" });
            AddColumn("dbo.Users", "TaxOfficeId", c => c.Long(nullable: false));
        }

        public override void Down()
        {
            AddColumn("dbo.Users", "TaxOffice_Id", c => c.Int());
            DropColumn("dbo.Users", "TaxOfficeId");
            CreateIndex("dbo.Users", "TaxOffice_Id");
            AddForeignKey("dbo.Users", "TaxOffice_Id", "dbo.TaxOffices", "Id");
        }
    }
}
