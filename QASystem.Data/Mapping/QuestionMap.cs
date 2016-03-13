using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class QuestionMap : EntityTypeConfiguration<Question>
    {
        public QuestionMap()
        {
            this.ToTable("Question");
            this.Property(u => u.Title).HasMaxLength(200);
            this.Property(u => u.Content).HasMaxLength(null);
            this.HasRequired(u => u.Author).WithMany().HasForeignKey(u => u.AuthorId).WillCascadeOnDelete();
            this.HasRequired(u => u.Topic).WithMany(u => u.Questions).HasForeignKey(u => u.TopicId).WillCascadeOnDelete();
        }
    }
}
