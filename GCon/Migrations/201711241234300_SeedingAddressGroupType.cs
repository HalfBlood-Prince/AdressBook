namespace GCon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingAddressGroupType : DbMigration
    {
        public override void Up()
        {
            Sql(@"

                SET IDENTITY_INSERT [dbo].[AddressGroupTypes] ON
                INSERT INTO [dbo].[AddressGroupTypes] ([Id], [Name]) VALUES (1, N'Family')
                INSERT INTO [dbo].[AddressGroupTypes] ([Id], [Name]) VALUES (2, N'Friends')
                INSERT INTO [dbo].[AddressGroupTypes] ([Id], [Name]) VALUES (3, N'Office')
                SET IDENTITY_INSERT [dbo].[AddressGroupTypes] OFF

                ");
        }
        
        public override void Down()
        {
        }
    }
}
