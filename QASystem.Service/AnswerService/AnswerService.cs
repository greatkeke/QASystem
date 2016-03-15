using QASystem.Core;
using QASystem.Core.Domain;
using System;
using System.Linq;

namespace QASystem.Service.AnswerService
{
    public class AnswerService : IAnswerService
    {
        private IUnitOfWork _uow;
        private IRepository<Answer> _answerRepository;

        public AnswerService(IUnitOfWork uow, IRepository<Answer> answerRepository)
        {
            _uow = uow;
            _answerRepository = answerRepository;
        }

        public Answer Add(int questionId, string answerContent, int anthorId)
        {
            var answer = new Answer()
            {
                AuthorId = anthorId,
                QuestionId = questionId,
                CreateDateUtc = DateTime.UtcNow,
                Content = answerContent
            };
            var res = _answerRepository.Insert(answer);
            if (_uow.SaveChanges() > 0)
            {
                res = _answerRepository.TableNoTracking.FirstOrDefault(u => u.Id == res.Id);
            }
            return res ?? null;
        }
    }
}
