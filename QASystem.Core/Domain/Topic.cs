using System.Collections.Generic;

namespace QASystem.Core.Domain
{
    public class Topic : BaseEntity
    {
        public string Name { get; set; }
        public double num { get; set; }
        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
