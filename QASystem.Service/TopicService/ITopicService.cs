using QASystem.Core.Domain;
using System.Collections.Generic;

namespace QASystem.Service.TopicService
{
    public interface ITopicService
    {
        IEnumerable<Topic> GetAll();
        /// <summary>
        /// 获取最热的话题
        /// </summary>
        /// <returns></returns>
        IEnumerable<Topic> GetHotTopics(int count);
    }
}
