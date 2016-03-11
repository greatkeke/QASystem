using System;
using System.Collections.Generic;

namespace QASystem.Core.Domain
{
    public class Answer : BaseEntity
    {
        public string Content { get; set; }
        public int Votes { get; set; }
        public int AuthorId { get; set; }
        public virtual User Author { get; set; }
        /// <summary>
        /// 回答时间
        /// </summary>
        public DateTime CreateDateUtc { get; set; }

        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }

        /// <summary>
        /// 评论
        /// </summary>
        public virtual ICollection<AnswerComment> Comments { get; set; }
    }
}