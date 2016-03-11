using QASystem.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace QASystem.Data.Mapping
{
    public class AnswerCommentMap : EntityTypeConfiguration<AnswerComment>
    {
        public AnswerCommentMap()
        {
            this.ToTable("AnswerComment");
            this.HasRequired(u => u.Answer).WithMany(u => u.Comments).HasForeignKey(u => u.AnswerId).WillCascadeOnDelete();
            this.HasRequired(u => u.FromUser).WithMany().HasForeignKey(u => u.FromUserId).WillCascadeOnDelete();
            this.HasRequired(u => u.ToUser).WithMany().HasForeignKey(u => u.ToUserId).WillCascadeOnDelete();
        }
    }
}
