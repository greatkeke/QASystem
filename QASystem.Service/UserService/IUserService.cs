using QASystem.Core.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace QASystem.Service.UserService
{
    public interface IUserService
    {
        int Add(User user);
        Task<int> AddAsync(User user, CancellationToken token);
    }
}
