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
        }
    }
}
