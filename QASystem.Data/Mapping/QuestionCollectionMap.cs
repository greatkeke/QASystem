using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class QuestionCollectionMap : EntityTypeConfiguration<QuestionCollection>
    {
        public QuestionCollectionMap()
        {
            this.ToTable("QuestionCollection");
            this.HasRequired(u => u.Question).WithMany().HasForeignKey(u => u.QuestionId).WillCascadeOnDelete();
            this.HasRequired(u => u.Collector).WithMany().HasForeignKey(u => u.CollectorId).WillCascadeOnDelete();

        }
    }
}
