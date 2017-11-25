namespace GCon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAddressGroup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        AddedDay = c.DateTime(nullable: false),
                        AddressGroupTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AddressGroupTypes", t => t.AddressGroupTypeId, cascadeDelete: true)
                .Index(t => t.AddressGroupTypeId);
            
            CreateTable(
                "dbo.AddressGroupTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressGroups", "AddressGroupTypeId", "dbo.AddressGroupTypes");
            DropIndex("dbo.AddressGroups", new[] { "AddressGroupTypeId" });
            DropTable("dbo.AddressGroupTypes");
            DropTable("dbo.AddressGroups");
        }
    }
}
