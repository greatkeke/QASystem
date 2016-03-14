namespace QASystem.Core.Domain
{
    public class TopicCollection : BaseEntity
    {
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public int CollectorId { get; set; }
        public virtual User Collector { get; set; }
    }
}
