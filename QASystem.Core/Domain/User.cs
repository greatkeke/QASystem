using System;

namespace QASystem.Core.Domain
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreateDateUtc { get; set; }
        //其它信息

    }
}