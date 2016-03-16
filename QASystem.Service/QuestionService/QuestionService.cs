using System;
using System.Collections.Generic;
using QASystem.Core.Domain;
using QASystem.Core;
using System.Linq;
using QASystem.Core.DTOModels;
using System.Threading.Tasks;

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
                res = _questionRepository.TableNoTracking.FirstOrDefault(u => u.Id == res.Id);
            }
            return res ?? null;
        }

        public Question GetByIdNoTracking(int id)
        {
            return _questionRepository.TableNoTracking.FirstOrDefault(u => u.Id == id);
        }

        public IPagedList<QuestionDto> ListBySubject(int id, int pageIndex, int pageSize)
        {
            var query = _questionRepository.Table
                .OrderByDescending(u => u.Votes)//按照热度降序排序
                .OrderByDescending(u => u.DateEndUtc)//日期次之
                .Where(u => u.Status > (int)QuestionStatus.Created && u.Status < (int)QuestionStatus.Deleted)//状态
                .Where(u => id <= 0 || u.Topic.SubjectId == id)//主题编号小于0时，查找所有主题
                .Select(u => new QuestionDto()//按需索取
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
