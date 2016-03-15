using QASystem.Core;
using QASystem.Core.Domain;
using QASystem.Core.DTOModels;
using System;
using System.Collections.Generic;

namespace QASystem.Service.QuestionService
{
    public interface IQuestionService
    {
        /// <summary>
        /// 查找（start）之后的问题，并按照热度进行排序。
        /// </summary>
        /// <param name="start"></param>
        /// <returns></returns>
        IEnumerable<Question> ListSortbyVote(DateTime start);

        /// <summary>
        /// 取（pageSize）个最新的问题
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedList<QuestionDto> NewestList(int pageIndex,int pageSize);

        Question Add(Question question);
        Question GetByIdNoTracking(int id);
        IPagedList<QuestionDto> ListBySubject(int id, int pageIndex, int pageSize);
    }
}
