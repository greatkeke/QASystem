namespace QASystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "QuestionCollection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User", t => t.userId, cascadeDelete: true)
                .ForeignKey("Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.userId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "TopicCollection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("Topic", t => t.TopicId, cascadeDelete: true)
                .Index(t => t.TopicId)
                .Index(t => t.UserId);
            
            CreateTable(
                "UserCollection",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WatchedId = c.Int(nullable: false),
                        WatchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User", t => t.WatchedId, cascadeDelete: true)
                .ForeignKey("User", t => t.WatchId, cascadeDelete: true)
                .Index(t => t.WatchedId)
                .Index(t => t.WatchId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("UserCollection", "WatchId", "User");
            DropForeignKey("UserCollection", "WatchedId", "User");
            DropForeignKey("TopicCollection", "TopicId", "Topic");
            DropForeignKey("TopicCollection", "UserId", "User");
            DropForeignKey("QuestionCollection", "QuestionId", "Question");
            DropForeignKey("QuestionCollection", "userId", "User");
            DropIndex("UserCollection", new[] { "WatchId" });
            DropIndex("UserCollection", new[] { "WatchedId" });
            DropIndex("TopicCollection", new[] { "UserId" });
            DropIndex("TopicCollection", new[] { "TopicId" });
            DropIndex("QuestionCollection", new[] { "QuestionId" });
            DropIndex("QuestionCollection", new[] { "userId" });
            DropTable("UserCollection");
            DropTable("TopicCollection");
            DropTable("QuestionCollection");
        }
    }
}
