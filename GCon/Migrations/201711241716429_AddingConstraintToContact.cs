namespace GCon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingConstraintToContact : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Contacts", "Address", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Contacts", "Name", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
