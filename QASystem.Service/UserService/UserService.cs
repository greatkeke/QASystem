using QASystem.Core;
using QASystem.Core.Domain;
using System.Linq;

namespace QASystem.Service.UserService
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;
        private IRepository<User> _userRepository;
        private IRepository<QuestionCollection> _questionCollectionRepository;
        private IRepository<UserCollection> _userCollectionRepository;
        private IRepository<TopicCollection> _topicCollectionRepository;

        public UserService(IUnitOfWork uow, IRepository<User> userRepository, IRepository<QuestionCollection> questionCollectionRepository, IRepository<UserCollection> userCollectionRepository, IRepository<TopicCollection> topicCollectionRepository)
        {
            _uow = uow;
            _userRepository = userRepository;
            _questionCollectionRepository = questionCollectionRepository;
            _userCollectionRepository = userCollectionRepository;
            _topicCollectionRepository = topicCollectionRepository;
        }


        public int QuestionCollectionCount(int userId)
        {
            return _questionCollectionRepository.Table.Count(u => u.CollectorId == userId);
        }

        public int UserCollectionCount(int userId)
        {
            return _userCollectionRepository.Table.Count(u => u.WatchId == userId);
        }

        public int TopicCollectionCount(int userId)
        {
            return _topicCollectionRepository.Table.Count(u => u.CollectorId == userId);
        }
    }
}
