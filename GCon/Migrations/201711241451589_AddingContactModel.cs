namespace GCon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingContactModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(),
                        Address = c.String(nullable: false),
                        AddressGroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressGroups", t => t.AddressGroupId, cascadeDelete: true)
                .Index(t => t.AddressGroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contacts", "AddressGroupId", "dbo.AddressGroups");
            DropIndex("dbo.Contacts", new[] { "AddressGroupId" });
            DropTable("dbo.Contacts");
        }
    }
}
