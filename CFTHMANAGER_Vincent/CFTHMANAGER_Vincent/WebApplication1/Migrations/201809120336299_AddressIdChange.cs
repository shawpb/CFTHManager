namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressIdChange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Addresses", "PersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "PersonId", c => c.Int(nullable: false));
        }
    }
}
