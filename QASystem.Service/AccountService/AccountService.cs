using QASystem.Core.Domain;
using QASystem.Core;
using System.Linq;
using System;

namespace QASystem.Service.AccountService
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _uow;
        private IRepository<User> _userRepository;

        public AccountService(IUnitOfWork uow, IRepository<User> userRepository)
        {
            _uow = uow;
            _userRepository = userRepository;
        }

        public bool AddAccount(User user)
        {
            //过滤重复的邮箱和用户名
            if (_userRepository.Table.Any(u => u.Email == user.Email )) return false;
            user.Password = DataHelper.MD5(user.Password);//密码加密
            _userRepository.Insert(user);
            return _uow.SaveChanges() > 0;
        }

        public User GetById(int userId)
        {
            return _userRepository.GetById(userId);
        }

        public User Login(string emial, string password)
        {
            var user = _userRepository.Table.FirstOrDefault(u => u.Email == emial);
            if (user != null)
            {
                if (user.Password == DataHelper.MD5(password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
