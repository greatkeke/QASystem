using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class QuestionCategoryMap : EntityTypeConfiguration<QuestionCategory>
    {
        public QuestionCategoryMap()
        {
            this.ToTable("QuestionCategory");
            this.Property(u => u.Name).HasMaxLength(200);
        }
    }
}
