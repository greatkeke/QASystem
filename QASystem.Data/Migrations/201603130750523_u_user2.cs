namespace QASystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u_user2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("User", "Email", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AlterColumn("User", "Password", c => c.String(maxLength: 100, storeType: "nvarchar"));
            AlterColumn("User", "ImgUrl", c => c.String(maxLength: 500, storeType: "nvarchar"));
            DropColumn("User", "UserGuid");
        }
        
        public override void Down()
        {
            AddColumn("User", "UserGuid", c => c.Guid(nullable: false));
            AlterColumn("User", "ImgUrl", c => c.String(unicode: false));
            AlterColumn("User", "Password", c => c.String(unicode: false));
            DropColumn("User", "Email");
        }
    }
}
