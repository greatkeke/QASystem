using QASystem.Service.QuestionService;
using QASystem.Service.TopicService;
using QASystem.Web.Attributes;
using System;
using System.Web.Mvc;

namespace QASystem.Web.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        private ITopicService _tagService;

        public QuestionController(IQuestionService questionService, ITopicService tagService)
        {
            _questionService = questionService;
            _tagService = tagService;
        }

        [HttpGet]
        public ActionResult ListByCategory(int cateId)
        {
            return View();
        }
        [HttpGet]
        [Skip]
        public ActionResult Index()
        {
            ViewBag.Questions = _questionService.NewestList(0, 25);
            return View();
        }
    }
}