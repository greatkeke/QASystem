using Microsoft.VisualStudio.TestTools.UnitTesting;
using QASystem.Core;
using QASystem.Core.Domain;
using QASystem.Data;
using System;

namespace QASystem.Service.UserService.Tests
{
    [TestClass()]
    public class UserServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            IUnitOfWork uow = new QASystemDbContext("QASystemDb");
            IUserService service = new UserService(new EfRepository<User>(uow), uow);
            service.Add(new User()
            {
                Name = "test",
                CreateDateUtc = DateTime.UtcNow,
                Email = "test@test.com"
            });
            Assert.AreEqual(1, uow.SaveChanges());
        }
    }
}