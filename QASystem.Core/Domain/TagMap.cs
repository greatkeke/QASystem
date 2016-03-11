namespace QASystem.Core.Domain
{
    /// <summary>
    /// tag和question的关系
    /// </summary>
    public class TagMap : BaseEntity
    {
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
