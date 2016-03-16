namespace QASystem.Service.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// 问题收藏总计
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        int QuestionCollectionCount(int userId);
        /// <summary>
        /// 用户关注总计
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        int UserCollectionCount(int userId);
        /// <summary>
        /// 话题收藏总计
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        int TopicCollectionCount(int userId);
    }
}
