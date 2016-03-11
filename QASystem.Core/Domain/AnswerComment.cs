using System;

namespace QASystem.Core.Domain
{
    public class AnswerComment : BaseEntity
    {
        public string Content { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
        /// <summary>
        /// 评论者
        /// </summary>
        public int FromUserId { get; set; }
        public virtual User FromUser { get; set; }
        /// <summary>
        /// 被评论者
        /// </summary>
        public int ToUserId { get; set; }
        public virtual User ToUser { get; set; }

    }
}