namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3004 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clusters", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Clusters", "IPAdress", c => c.String(nullable: false));
            AddColumn("dbo.Clusters", "Subnetwork", c => c.String(nullable: false));
            AddColumn("dbo.Servers", "IPAdress", c => c.String(nullable: false));
            AddColumn("dbo.Servers", "Subnetwork", c => c.String(nullable: false));
            AddColumn("dbo.Servers", "ClusterID", c => c.Int());
            CreateIndex("dbo.Servers", "ClusterID");
            AddForeignKey("dbo.Servers", "ClusterID", "dbo.Clusters", "Id");
            DropColumn("dbo.Clusters", "Adress");
            DropColumn("dbo.Clusters", "Subnet");
            DropColumn("dbo.Servers", "Adress");
            DropColumn("dbo.Servers", "Subnet");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servers", "Subnet", c => c.String(nullable: false));
            AddColumn("dbo.Servers", "Adress", c => c.String(nullable: false));
            AddColumn("dbo.Clusters", "Subnet", c => c.String(nullable: false));
            AddColumn("dbo.Clusters", "Adress", c => c.String(nullable: false));
            DropForeignKey("dbo.Servers", "ClusterID", "dbo.Clusters");
            DropIndex("dbo.Servers", new[] { "ClusterID" });
            DropColumn("dbo.Servers", "ClusterID");
            DropColumn("dbo.Servers", "Subnetwork");
            DropColumn("dbo.Servers", "IPAdress");
            DropColumn("dbo.Clusters", "Subnetwork");
            DropColumn("dbo.Clusters", "IPAdress");
            DropColumn("dbo.Clusters", "Name");
        }
    }
}
