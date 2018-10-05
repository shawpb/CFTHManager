namespace CFTHManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrtion1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "Advocate_Id", "dbo.People");
            DropForeignKey("dbo.Clients", "DataEntryPerson_Id", "dbo.People");
            DropForeignKey("dbo.Clients", "IntakePerson_Id", "dbo.People");
            DropForeignKey("dbo.Clients", "PersonalInformation_Id", "dbo.People");
            DropIndex("dbo.Clients", new[] { "Advocate_Id" });
            DropIndex("dbo.Clients", new[] { "DataEntryPerson_Id" });
            DropIndex("dbo.Clients", new[] { "IntakePerson_Id" });
            DropIndex("dbo.Clients", new[] { "PersonalInformation_Id" });
            RenameColumn(table: "dbo.Clients", name: "Advocate_Id", newName: "AdvocateId");
            RenameColumn(table: "dbo.Clients", name: "DataEntryPerson_Id", newName: "DataEntryPersonId");
            RenameColumn(table: "dbo.Clients", name: "IntakePerson_Id", newName: "IntakePersonId");
            RenameColumn(table: "dbo.Clients", name: "PersonalInformation_Id", newName: "PersonalInformationId");
            AlterColumn("dbo.Clients", "AdvocateId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "DataEntryPersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "IntakePersonId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "PersonalInformationId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "PersonalInformationId");
            CreateIndex("dbo.Clients", "AdvocateId");
            CreateIndex("dbo.Clients", "IntakePersonId");
            CreateIndex("dbo.Clients", "DataEntryPersonId");
            AddForeignKey("dbo.Clients", "AdvocateId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "DataEntryPersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "IntakePersonId", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Clients", "PersonalInformationId", "dbo.People", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "PersonalInformationId", "dbo.People");
            DropForeignKey("dbo.Clients", "IntakePersonId", "dbo.People");
            DropForeignKey("dbo.Clients", "DataEntryPersonId", "dbo.People");
            DropForeignKey("dbo.Clients", "AdvocateId", "dbo.People");
            DropIndex("dbo.Clients", new[] { "DataEntryPersonId" });
            DropIndex("dbo.Clients", new[] { "IntakePersonId" });
            DropIndex("dbo.Clients", new[] { "AdvocateId" });
            DropIndex("dbo.Clients", new[] { "PersonalInformationId" });
            AlterColumn("dbo.Clients", "PersonalInformationId", c => c.Int());
            AlterColumn("dbo.Clients", "IntakePersonId", c => c.Int());
            AlterColumn("dbo.Clients", "DataEntryPersonId", c => c.Int());
            AlterColumn("dbo.Clients", "AdvocateId", c => c.Int());
            RenameColumn(table: "dbo.Clients", name: "PersonalInformationId", newName: "PersonalInformation_Id");
            RenameColumn(table: "dbo.Clients", name: "IntakePersonId", newName: "IntakePerson_Id");
            RenameColumn(table: "dbo.Clients", name: "DataEntryPersonId", newName: "DataEntryPerson_Id");
            RenameColumn(table: "dbo.Clients", name: "AdvocateId", newName: "Advocate_Id");
            CreateIndex("dbo.Clients", "PersonalInformation_Id");
            CreateIndex("dbo.Clients", "IntakePerson_Id");
            CreateIndex("dbo.Clients", "DataEntryPerson_Id");
            CreateIndex("dbo.Clients", "Advocate_Id");
            AddForeignKey("dbo.Clients", "PersonalInformation_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Clients", "IntakePerson_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Clients", "DataEntryPerson_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Clients", "Advocate_Id", "dbo.People", "Id");
        }
    }
}
