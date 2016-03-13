using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class TopicCollectionMap : EntityTypeConfiguration<TopicCollection>
    {
        public TopicCollectionMap()
        {
            this.ToTable("TopicCollection");
            this.HasRequired(u => u.Collector).WithMany().HasForeignKey(u => u.UserId).WillCascadeOnDelete();
            this.HasRequired(u => u.Topic).WithMany().HasForeignKey(u => u.TopicId).WillCascadeOnDelete();
        }
    }
}
