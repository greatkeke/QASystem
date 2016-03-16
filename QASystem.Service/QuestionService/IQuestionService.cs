using QASystem.Core;
using QASystem.Core.Domain;
using QASystem.Core.DTOModels;

namespace QASystem.Service.QuestionService
{
    public interface IQuestionService
    {
        Question Add(Question question);
        Question GetByIdNoTracking(int id);
        /// <summary>
        /// 获取按照主题分类的分页数据集合
        /// </summary>
        /// <param name="id">主题编号</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<QuestionDto> ListBySubject(int id, int pageIndex, int pageSize);
    }
}
