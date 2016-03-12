using System;
using System.Collections.Generic;
using QASystem.Core.Domain;
using QASystem.Core;
using System.Linq;
using System.Threading.Tasks;

namespace QASystem.Service.QuestionCategoryService
{
    public class QuestionCategoryService : IQuestionCategoryService
    {
        private IUnitOfWork _uow;
        private IRepository<QuestionCategory> _questionCategoryRepository;

        public IQueryable<QuestionCategory> Table
        {
            get
            {
                return _questionCategoryRepository.Table;
            }
        }

        public QuestionCategoryService(IUnitOfWork uow, IRepository<QuestionCategory> questionCategoryRepository)
        {
            _uow = uow;
            _questionCategoryRepository = questionCategoryRepository;
        }

        public bool Add(QuestionCategory cate)
        {
            _questionCategoryRepository.Insert(cate);
            return _uow.SaveChanges() > 0;
        }

        public bool Delete(QuestionCategory cate)
        {
            _questionCategoryRepository.Delete(cate);
            return _uow.SaveChanges() > 0;
        }

        public IEnumerable<QuestionCategory> GetAll()
        {
            return _questionCategoryRepository.Table.ToList();
        }

        public bool Update(QuestionCategory cate)
        {
            _questionCategoryRepository.Update(cate);
            return _uow.SaveChanges() > 0;
        }

        public async Task<bool> Add(ICollection<QuestionCategory> cates)
        {
            foreach (var item in cates)
            {
                _questionCategoryRepository.Insert(item);
            }
            return await _uow.SaveChangesAsync() > 0;
        }

    }
}
