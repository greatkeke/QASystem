using QASystem.Core.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QASystem.Service.QuestionCategoryService
{
    public interface IQuestionCategoryService
    {
        bool Add(QuestionCategory cate);
        Task<bool> Add(ICollection<QuestionCategory> cates);
        bool Update(QuestionCategory cate);
        bool Delete(QuestionCategory cate);
        IEnumerable<QuestionCategory> GetAll();
        IQueryable<QuestionCategory> Table { get; }
    }
}
