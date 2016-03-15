using QASystem.Core;
using QASystem.Core.DTOModels;
using System.Collections.Generic;

namespace QASystem.Web.Models
{
    /// <summary>
    /// 问题列表-视图模型
    /// </summary>
    public class QuestionListViewModel
    {
        public IPagedList<QuestionDto> QuestionList;
        public int SubjectId;
        /// <summary>
        /// 用分页集合、主题编号构造问题列表-视图模型
        /// </summary>
        /// <param name="ques">分页集合</param>
        /// <param name="subjectId">主题编号(if编号不大于0，则展示所有主题)</param>
        public QuestionListViewModel(IPagedList<QuestionDto> ques, int subjectId)
        {
            QuestionList = ques;
            SubjectId = subjectId;
        }
    }
}