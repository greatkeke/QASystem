namespace QASystem.Core.Domain
{
    public class UserCollection : BaseEntity
    {
        /// <summary>
        /// 被关注者编号
        /// </summary>
        public int WatchedId { get; set; }
        /// <summary>
        /// 被关注者
        /// </summary>
        public virtual User WatchedUser { get; set; }

        /// <summary>
        /// 关注者编号
        /// </summary>
        public int WatchId { get; set; }
        /// <summary>
        /// 关注者
        /// </summary>
        public virtual User WatchUser { get; set; }
    }
}
