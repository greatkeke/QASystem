using System;
using System.Collections.Generic;
using QASystem.Core.Domain;
using QASystem.Core;
using System.Linq;
using QASystem.Core.DTOModels;

namespace QASystem.Service.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private IUnitOfWork _uow;
        private IRepository<Question> _questionRepository;

        public QuestionService(IUnitOfWork uow, IRepository<Question> questionRepository)
        {
            _uow = uow;
            _questionRepository = questionRepository;
        }

        public IEnumerable<Question> ListSortbyVote(DateTime start)
        {
            start = TimeZoneInfo.ConvertTimeToUtc(start);
            return _questionRepository.Table.Where(u => u.DateEndUtc > start).ToList();
        }

        public bool Add(Question question)
        {
            _questionRepository.Insert(question);
            return _uow.SaveChanges() > 0;
        }

        public IPagedList<QuestionDto> NewestList(int pageIndex, int pageSize)
        {
            var query = _questionRepository.Table.OrderByDescending(u => u.Id).Where(u => u.Status > (int)QuestionStatus.Created && u.Status < (int)QuestionStatus.Deleted).Select(u => new QuestionDto()
            {
                Id = u.Id,
                Title = u.Title,
                DateEndUtc = u.DateEndUtc,
                DateStartUtc = u.DateEndUtc,
                AuthorId = u.AuthorId,
                Author = u.Author,
                Status = u.Status,
                Topic = u.Topic,
                TopicId = u.TopicId,
                Votes = u.Votes
            });
            return new PagedList<QuestionDto>(query, pageIndex, pageSize);
        }
    }
}
