using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");
            HasKey(n => n.Id);
            Property(n => n.Username).HasMaxLength(100);
            Property(n => n.Email).HasMaxLength(100);
            Property(u => u.Password).HasMaxLength(100);
            Property(u => u.ImgUrl).HasMaxLength(500);
        }
    }
}
