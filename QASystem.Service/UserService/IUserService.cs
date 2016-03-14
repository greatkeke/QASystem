namespace QASystem.Service.UserService
{
    public interface IUserService
    {
        int QuestionCollectionCount(int userId);
        int UserCollectionCount(int userId);
        int TopicCollectionCount(int userId);
    }
}
