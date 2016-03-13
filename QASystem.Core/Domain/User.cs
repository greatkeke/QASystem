using System;

namespace QASystem.Core.Domain
{
    [Serializable]
    public class User : BaseEntity
    {
        /// <summary>
        /// 用户的GUID编号
        /// </summary>
        public Guid UserGuid { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public DateTime CreateDateUtc { get; set; }

        /// <summary>
        /// 密码格式
        /// </summary>
        public int PasswordFormatId { get; set; }

        /// <summary>
        /// 加密盐值
        /// </summary>
        public string PasswordSalt { get; set; }

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