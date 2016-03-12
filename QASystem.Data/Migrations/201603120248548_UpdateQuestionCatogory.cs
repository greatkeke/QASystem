namespace QASystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateQuestionCatogory : DbMigration
    {
        public override void Up()
        {
            CreateIndex("QuestionCategory", "ParentId");
            AddForeignKey("QuestionCategory", "ParentId", "QuestionCategory", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("QuestionCategory", "ParentId", "QuestionCategory");
            DropIndex("QuestionCategory", new[] { "ParentId" });
        }
    }
}
