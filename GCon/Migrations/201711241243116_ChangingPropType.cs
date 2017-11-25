namespace GCon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangingPropType : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AddressGroups", "AddressGroupTypeId", "dbo.AddressGroupTypes");
            DropIndex("dbo.AddressGroups", new[] { "AddressGroupTypeId" });
            DropPrimaryKey("dbo.AddressGroupTypes");
            AlterColumn("dbo.AddressGroups", "AddressGroupTypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.AddressGroupTypes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.AddressGroupTypes", "Id");
            CreateIndex("dbo.AddressGroups", "AddressGroupTypeId");
            AddForeignKey("dbo.AddressGroups", "AddressGroupTypeId", "dbo.AddressGroupTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddressGroups", "AddressGroupTypeId", "dbo.AddressGroupTypes");
            DropIndex("dbo.AddressGroups", new[] { "AddressGroupTypeId" });
            DropPrimaryKey("dbo.AddressGroupTypes");
            AlterColumn("dbo.AddressGroupTypes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AddressGroups", "AddressGroupTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AddressGroupTypes", "Id");
            CreateIndex("dbo.AddressGroups", "AddressGroupTypeId");
            AddForeignKey("dbo.AddressGroups", "AddressGroupTypeId", "dbo.AddressGroupTypes", "Id", cascadeDelete: true);
        }
    }
}
