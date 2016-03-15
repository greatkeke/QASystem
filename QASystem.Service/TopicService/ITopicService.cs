using QASystem.Core.Domain;
using System.Collections.Generic;

namespace QASystem.Service.TopicService
{
    public interface ITopicService
    {
        IEnumerable<Topic> GetAll();
        IEnumerable<Topic> GetHotTopics();
    }
}
