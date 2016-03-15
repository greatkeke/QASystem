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
        private IRepository<Topic> _topicRepository;

        public QuestionService(IUnitOfWork uow, IRepository<Question> questionRepository, IRepository<Topic> topicRepository)
        {
            _uow = uow;
            _questionRepository = questionRepository;
            _topicRepository = topicRepository;
        }

        public IEnumerable<Question> ListSortbyVote(DateTime start)
        {
            start = TimeZoneInfo.ConvertTimeToUtc(start);
            return _questionRepository.Table.Where(u => u.DateEndUtc > start).ToList();
        }

        public Question Add(Question question)
        {
            //当前主题下的该话题是否存在
            var topic = _topicRepository.Table.FirstOrDefault(u => u.Name == question.Topic.Name && u.SubjectId == u.SubjectId);
            if (topic != null)
            {
                question.Topic = topic;
                question.Topic.num++;//该话题下的问题数+1
            }

            var res = _questionRepository.Insert(question);
            if (_uow.SaveChanges() > 0)
            {
                res.Author = _questionRepository.GetById(res.Id).Author;
                res.Answers = _questionRepository.GetById(res.Id).Answers;
                res.Topic = _questionRepository.GetById(res.Id).Topic;
            }
            return null;
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

        public Question GetById(int id)
        {
            return _questionRepository.GetById(id);
        }
    }
}
