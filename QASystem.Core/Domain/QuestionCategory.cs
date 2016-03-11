namespace QASystem.Core.Domain
{
    public class QuestionCategory : BaseEntity
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}
