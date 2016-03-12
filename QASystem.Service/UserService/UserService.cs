using QASystem.Core.Domain;
using QASystem.Core;
using System.Threading.Tasks;
using System.Threading;

namespace QASystem.Service.UserService
{
    public class UserService : IUserService
    {
        private IUnitOfWork _uow;
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRep, IUnitOfWork uow)
        {
            _userRepository = userRep;
            _uow = uow;
        }

        public int Add(User user)
        {
            _userRepository.Insert(user);
            return _uow.SaveChanges();
        }

        public async Task<int> AddAsync(User user, CancellationToken token)
        {
            _userRepository.Insert(user);
            return await _uow.SaveChangesAsync(token);
        }
        
    }
}
