using QASystem.Service.TopicService;
using QASystem.Web.Attributes;
using System.Web.Mvc;

namespace QASystem.Web.Controllers
{
    public class TopicController : Controller
    {
        private ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        /// <summary>
        /// 热门话题
        /// </summary>
        /// <returns></returns>
        [ChildActionOnly]
        [LoginSkip]
        public PartialViewResult HotTopics()
        {
            ViewBag.Topics = _topicService.GetHotTopics();
            return PartialView();
        }
    }
}