using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class TagMapMap : EntityTypeConfiguration<TagMap>
    {
        public TagMapMap()
        {
            this.ToTable("TagMap");
            this.HasRequired(u => u.Question).WithMany().HasForeignKey(u => u.QuestionId).WillCascadeOnDelete();
            this.HasRequired(u => u.Tag).WithMany().HasForeignKey(u => u.TagId).WillCascadeOnDelete();
        }
    }
}
