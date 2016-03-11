using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class Tag_Map : EntityTypeConfiguration<Tag>
    {
        public Tag_Map()
        {
            this.ToTable("Tag");
            this.Property(u => u.Name).HasMaxLength(200);
        }
    }
}
