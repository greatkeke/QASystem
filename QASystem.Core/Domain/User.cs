using System;

namespace QASystem.Core.Domain
{
    [Serializable]
    public class User : BaseEntity
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public DateTime CreateDateUtc { get; set; }

        public string ImgUrl { get; set; }

        /// <summary>
        /// 用户是否有效
        /// </summary>
        public bool Active { get; set; }

        /// <summary>
        /// 是否被删除
        /// </summary>
        public bool Deleted { get; set; }

    }
}