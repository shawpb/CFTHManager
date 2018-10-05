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
                        FamilySize = c.Int(nullable: false),
                        AgencyPickUp = c.Boolean(nullable: false),
                        CfhToDeliver = c.Boolean(nullable: false),
                        EnteredDate = c.DateTime(nullable: false),
                        Advocate_Id = c.Int(),
                        DataEntryPerson_Id = c.Int(),
                        IntakePerson_Id = c.Int(),
                        PersonalInformation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.Advocate_Id)
                .ForeignKey("dbo.People", t => t.DataEntryPerson_Id)
                .ForeignKey("dbo.People", t => t.IntakePerson_Id)
                .ForeignKey("dbo.People", t => t.PersonalInformation_Id)
                .Index(t => t.Advocate_Id)
                .Index(t => t.DataEntryPerson_Id)
                .Index(t => t.IntakePerson_Id)
                .Index(t => t.PersonalInformation_Id);
            
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
            DropForeignKey("dbo.Clients", "PersonalInformation_Id", "dbo.People");
            DropForeignKey("dbo.Clients", "IntakePerson_Id", "dbo.People");
            DropForeignKey("dbo.Clients", "DataEntryPerson_Id", "dbo.People");
            DropForeignKey("dbo.Clients", "Advocate_Id", "dbo.People");
            DropForeignKey("dbo.People", "MainAddress_Id", "dbo.Addresses");
            DropIndex("dbo.People", new[] { "MainAddress_Id" });
            DropIndex("dbo.Clients", new[] { "PersonalInformation_Id" });
            DropIndex("dbo.Clients", new[] { "IntakePerson_Id" });
            DropIndex("dbo.Clients", new[] { "DataEntryPerson_Id" });
            DropIndex("dbo.Clients", new[] { "Advocate_Id" });
            DropTable("dbo.People");
            DropTable("dbo.Clients");
            DropTable("dbo.Addresses");
        }
    }
}
