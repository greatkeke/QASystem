using System.Collections.Generic;

namespace QASystem.Core.Domain
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}
