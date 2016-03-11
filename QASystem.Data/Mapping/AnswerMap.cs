using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class AnswerMap : EntityTypeConfiguration<Answer>
    {
        public AnswerMap()
        {
            this.ToTable("Answer");
            this.Property(u => u.Content).HasMaxLength(null);
            this.HasRequired(u => u.Author).WithMany().HasForeignKey(u => u.AuthorId).WillCascadeOnDelete();
            this.HasRequired(u => u.Question).WithMany(u => u.Answers).HasForeignKey(u => u.QuestionId).WillCascadeOnDelete();
        }
    }
}
