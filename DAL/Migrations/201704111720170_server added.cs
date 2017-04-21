namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serveradded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Servers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Adress = c.String(nullable: false),
                        SubnetMask = c.String(nullable: false),
                        Subnet = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Servers");
        }
    }
}
