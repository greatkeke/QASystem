namespace QASystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u_Topic : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("QuestionCollection", "userId", "User");
            DropForeignKey("QuestionCollection", "QuestionId", "Question");
            //DropForeignKey("TopicCollection", "UserId", "User");
            DropForeignKey("TopicCollection", "TopicId", "Topic");
            //DropIndex("QuestionCollection", new[] { "userId" });
            DropIndex("QuestionCollection", new[] { "QuestionId" });
            DropIndex("TopicCollection", new[] { "TopicId" });
            //DropIndex("TopicCollection", new[] { "UserId" });
            AddColumn("QuestionCollection", "CollectorId", c => c.Int(nullable: false));
            AddColumn("TopicCollection", "CollectorId", c => c.Int(nullable: false));
            DropColumn("QuestionCollection", "userId");
            DropColumn("TopicCollection", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("TopicCollection", "UserId", c => c.Int(nullable: false));
            AddColumn("QuestionCollection", "userId", c => c.Int(nullable: false));
            DropColumn("TopicCollection", "CollectorId");
            DropColumn("QuestionCollection", "CollectorId");
            CreateIndex("TopicCollection", "UserId");
            CreateIndex("TopicCollection", "TopicId");
            CreateIndex("QuestionCollection", "QuestionId");
            CreateIndex("QuestionCollection", "userId");
            AddForeignKey("TopicCollection", "TopicId", "Topic", "Id", cascadeDelete: true);
            AddForeignKey("TopicCollection", "UserId", "User", "Id", cascadeDelete: true);
            AddForeignKey("QuestionCollection", "QuestionId", "Question", "Id", cascadeDelete: true);
            AddForeignKey("QuestionCollection", "userId", "User", "Id", cascadeDelete: true);
        }
    }
}
