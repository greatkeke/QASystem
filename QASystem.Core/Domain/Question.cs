using System;
using System.Collections.Generic;

namespace QASystem.Core.Domain
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DateStartUtc { get; set; }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime DateEndUtc { get; set; }

        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        /// <summary>
        /// 被赞数
        /// </summary>
        public int Votes { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public Int16 Status { get; set; }

        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
