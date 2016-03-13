using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class TopicMap : EntityTypeConfiguration<Topic>
    {
        public TopicMap()
        {
            this.ToTable("Topic");
            this.Property(u => u.Name).HasMaxLength(200);
            this.HasRequired(u => u.Subject).WithMany(u => u.Topics).HasForeignKey(u => u.SubjectId).WillCascadeOnDelete();
        }
    }
}
