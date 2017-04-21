namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clusteradded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clusters",
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
            DropTable("dbo.Clusters");
        }
    }
}
