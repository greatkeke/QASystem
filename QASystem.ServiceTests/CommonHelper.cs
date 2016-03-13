using QASystem.Core;
using QASystem.Core.Domain;
using QASystem.Data;
using QASystem.Service.SubjectService;
using QASystem.Service.QuestionService;

namespace QASystem.ServiceTests
{
    class CommonHelper
    {
        internal static IUnitOfWork Uow = new QASystemDbContext("QASystemDb");
        //internal static IUserService UserService = new UserService(new EfRepository<User>(Uow), Uow);
        internal static ISubjectService QuestionCategoryService = new SubjectService(Uow, new EfRepository<Subject>(Uow));

        public static IQuestionService QuestionService = new QuestionService(Uow, new EfRepository<Question>(Uow));
    }
}
