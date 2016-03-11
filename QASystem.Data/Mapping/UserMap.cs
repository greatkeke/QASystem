using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.Property(u => u.Name).HasMaxLength(200);
            this.Property(u => u.Email).HasMaxLength(200);
        }
    }
}
