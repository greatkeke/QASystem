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

        public static IQuestionService QuestionService = new QuestionService(Uow, new EfRepository<Question>(Uow), new EfRepository<Topic>(Uow));
        public static ISubjectService SubjectService = new SubjectService(Uow, new EfRepository<Subject>(Uow));
    }
}
