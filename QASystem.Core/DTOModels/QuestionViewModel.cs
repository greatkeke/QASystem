using QASystem.Core.Domain;
using System;

namespace QASystem.Core.DTOModels
{
    /// <summary>
    /// QuestionDto模型：用于列表展示，不附加具体内容，利于传输
    /// </summary>
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime DateStartUtc { get; set; }
        public DateTime DateStart
        {
            get
            {
                return TimeZoneInfo.ConvertTimeFromUtc(DateStartUtc, TimeZoneInfo.Local);
            }
            set
            {
                DateStartUtc = TimeZoneInfo.ConvertTimeToUtc(value);
            }
        }
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime DateEndUtc { get; set; }
        public DateTime DateEnd
        {
            get
            {
                return TimeZoneInfo.ConvertTimeFromUtc(DateEndUtc, TimeZoneInfo.Local);
            }
            set
            {
                DateEndUtc = TimeZoneInfo.ConvertTimeToUtc(value);
            }
        }

        public int AuthorId { get; set; }
        public virtual User Author { get; set; }

        /// <summary>
        /// 被赞数
        /// </summary>
        public int Votes { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public Int16 Status { get; set; }

        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
