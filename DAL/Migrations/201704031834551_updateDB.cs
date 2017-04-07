namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDB : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserAccounts", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.UserAccounts", "HashOfPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserAccounts", "HashOfPassword", c => c.String());
            AlterColumn("dbo.UserAccounts", "Name", c => c.String());
        }
    }
}
