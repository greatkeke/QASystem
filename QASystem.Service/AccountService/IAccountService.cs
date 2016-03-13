using QASystem.Core.Domain;

namespace QASystem.Service.AccountService
{
    public interface IAccountService
    {
        bool AddAccount(User user);
        User Login(string email, string password);
        User GetById(int userId);
    }
}
