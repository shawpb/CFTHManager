namespace CFTHManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        Street2 = c.String(),
                        ApartmentNumber = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonalInformationId = c.Int(nullable: false),
                        AdvocateId = c.Int(),
                        IntakePersonId = c.Int(),
                        DataEntryPersonId = c.Int(),
                        FamilySize = c.Int(nullable: false),
                        AgencyPickUp = c.Boolean(nullable: false),
                        CfhToDeliver = c.Boolean(nullable: false),
                        EnteredDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.AdvocateId)
                .ForeignKey("dbo.People", t => t.DataEntryPersonId)
                .ForeignKey("dbo.People", t => t.IntakePersonId)
                .ForeignKey("dbo.People", t => t.PersonalInformationId, cascadeDelete: true)
                .Index(t => t.PersonalInformationId)
                .Index(t => t.AdvocateId)
                .Index(t => t.IntakePersonId)
                .Index(t => t.DataEntryPersonId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PhoneNumber = c.String(),
                        EmailAddress = c.String(),
                        MainAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.MainAddress_Id)
                .Index(t => t.MainAddress_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "PersonalInformationId", "dbo.People");
            DropForeignKey("dbo.Clients", "IntakePersonId", "dbo.People");
            DropForeignKey("dbo.Clients", "DataEntryPersonId", "dbo.People");
            DropForeignKey("dbo.Clients", "AdvocateId", "dbo.People");
            DropForeignKey("dbo.People", "MainAddress_Id", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "MainAddress_Id" });
            DropIndex("dbo.Clients", new[] { "DataEntryPersonId" });
            DropIndex("dbo.Clients", new[] { "IntakePersonId" });
            DropIndex("dbo.Clients", new[] { "AdvocateId" });
            DropIndex("dbo.Clients", new[] { "PersonalInformationId" });
            DropTable("dbo.People");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
