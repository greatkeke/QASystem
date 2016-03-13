using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class UserCollectionMap : EntityTypeConfiguration<UserCollection>
    {
        public UserCollectionMap()
        {
            this.ToTable("UserCollection");
            this.HasRequired(u => u.WatchedUser).WithMany().HasForeignKey(u => u.WatchedId).WillCascadeOnDelete();
            this.HasRequired(u => u.WatchUser).WithMany().HasForeignKey(u => u.WatchId).WillCascadeOnDelete();
        }
    }
}
