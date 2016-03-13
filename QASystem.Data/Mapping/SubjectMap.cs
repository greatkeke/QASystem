using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class SubjectMap : EntityTypeConfiguration<Subject>
    {
        public SubjectMap()
        {
            this.ToTable("Subject");
            this.Property(u => u.Name).HasMaxLength(200);
        }
    }
}
