namespace QASystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u_user : DbMigration
    {
        public override void Up()
        {
            AddColumn("User", "UserGuid", c => c.Guid(nullable: false));
            AddColumn("User", "Username", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AddColumn("User", "Password", c => c.String(unicode: false));
            AddColumn("User", "ImgUrl", c => c.String(unicode: false));
            AddColumn("User", "Active", c => c.Boolean(nullable: false));
            AddColumn("User", "Deleted", c => c.Boolean(nullable: false));
            DropColumn("User", "Name");
            DropColumn("User", "Email");
        }
        
        public override void Down()
        {
            AddColumn("User", "Email", c => c.String(maxLength: 200, storeType: "nvarchar"));
            AddColumn("User", "Name", c => c.String(maxLength: 200, storeType: "nvarchar"));
            DropColumn("User", "Deleted");
            DropColumn("User", "Active");
            DropColumn("User", "ImgUrl");
            DropColumn("User", "Password");
            DropColumn("User", "Username");
            DropColumn("User", "UserGuid");
        }
    }
}
