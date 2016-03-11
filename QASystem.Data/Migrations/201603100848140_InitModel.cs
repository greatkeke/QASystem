namespace QASystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "AnswerComment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(unicode: false),
                        CreateDateUtc = c.DateTime(nullable: false, precision: 0),
                        AnswerId = c.Int(nullable: false),
                        FromUserId = c.Int(nullable: false),
                        ToUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Answer", t => t.AnswerId, cascadeDelete: true)
                .ForeignKey("User", t => t.FromUserId, cascadeDelete: true)
                .ForeignKey("User", t => t.ToUserId, cascadeDelete: true)
                .Index(t => t.AnswerId)
                .Index(t => t.FromUserId)
                .Index(t => t.ToUserId);
            
            CreateTable(
                "Answer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(unicode: false),
                        Votes = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                        CreateDateUtc = c.DateTime(nullable: false, precision: 0),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User", t => t.AuthorId, cascadeDelete: true)
                .ForeignKey("Question", t => t.QuestionId, cascadeDelete: true)
                .Index(t => t.AuthorId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                        Email = c.String(maxLength: 200, storeType: "nvarchar"),
                        CreateDateUtc = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "Question",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200, storeType: "nvarchar"),
                        Content = c.String(unicode: false),
                        DateStartUtc = c.DateTime(nullable: false, precision: 0),
                        DateEndUtc = c.DateTime(nullable: false, precision: 0),
                        Votes = c.Int(nullable: false),
                        Status = c.Short(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("User", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "QuestionCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                        ParentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "TagMap",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TagId = c.Int(nullable: false),
                        QuestionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("Question", t => t.QuestionId, cascadeDelete: true)
                .ForeignKey("Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.QuestionId);
            
            CreateTable(
                "Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 200, storeType: "nvarchar"),
                        num = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("TagMap", "TagId", "Tag");
            DropForeignKey("TagMap", "QuestionId", "Question");
            DropForeignKey("AnswerComment", "ToUserId", "User");
            DropForeignKey("AnswerComment", "FromUserId", "User");
            DropForeignKey("AnswerComment", "AnswerId", "Answer");
            DropForeignKey("Answer", "QuestionId", "Question");
            DropForeignKey("Question", "Author_Id", "User");
            DropForeignKey("Answer", "AuthorId", "User");
            DropIndex("TagMap", new[] { "QuestionId" });
            DropIndex("TagMap", new[] { "TagId" });
            DropIndex("Question", new[] { "Author_Id" });
            DropIndex("Answer", new[] { "QuestionId" });
            DropIndex("Answer", new[] { "AuthorId" });
            DropIndex("AnswerComment", new[] { "ToUserId" });
            DropIndex("AnswerComment", new[] { "FromUserId" });
            DropIndex("AnswerComment", new[] { "AnswerId" });
            DropTable("Tag");
            DropTable("TagMap");
            DropTable("QuestionCategory");
            DropTable("Question");
            DropTable("User");
            DropTable("Answer");
            DropTable("AnswerComment");
        }
    }
}
