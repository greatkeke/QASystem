namespace QASystem.Core.Domain
{
    public class QuestionCollection : BaseEntity
    {
        public int CollectorId { get; set; }
        public virtual User Collector { get; set; }
        public int QuestionId { get; set; }
        public virtual Question Question { get; set; }
    }
}
