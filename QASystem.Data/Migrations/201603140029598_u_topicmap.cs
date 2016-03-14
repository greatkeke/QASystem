namespace QASystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class u_topicmap : DbMigration
    {
        public override void Up()
        {
            CreateIndex("QuestionCollection", "CollectorId");
            CreateIndex("QuestionCollection", "QuestionId");
            CreateIndex("TopicCollection", "TopicId");
            CreateIndex("TopicCollection", "CollectorId");
            AddForeignKey("QuestionCollection", "CollectorId", "User", "Id", cascadeDelete: true);
            AddForeignKey("QuestionCollection", "QuestionId", "Question", "Id", cascadeDelete: true);
            AddForeignKey("TopicCollection", "CollectorId", "User", "Id", cascadeDelete: true);
            AddForeignKey("TopicCollection", "TopicId", "Topic", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("TopicCollection", "TopicId", "Topic");
            DropForeignKey("TopicCollection", "CollectorId", "User");
            DropForeignKey("QuestionCollection", "QuestionId", "Question");
            DropForeignKey("QuestionCollection", "CollectorId", "User");
            DropIndex("TopicCollection", new[] { "CollectorId" });
            DropIndex("TopicCollection", new[] { "TopicId" });
            DropIndex("QuestionCollection", new[] { "QuestionId" });
            DropIndex("QuestionCollection", new[] { "CollectorId" });
        }
    }
}
