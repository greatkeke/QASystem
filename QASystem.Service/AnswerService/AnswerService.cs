using QASystem.Core;
using QASystem.Core.Domain;
using System;

namespace QASystem.Service.AnswerService
{
    public class AnswerService : IAnswerService
    {
        private IUnitOfWork _uow;
        private IRepository<Answer> _answerRepository;
        private IRepository<User> _userRepository;

        public AnswerService(IUnitOfWork uow, IRepository<Answer> answerRepository, IRepository<User> userRepository)
        {
            _uow = uow;
            _answerRepository = answerRepository;
            _userRepository = userRepository;
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
                res.Author = _userRepository.GetById(res.AuthorId);
                return res;
            }
            return null;
        }
    }
}
