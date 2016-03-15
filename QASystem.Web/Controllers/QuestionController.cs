using QASystem.Core.Domain;
using QASystem.Core.DTOModels;
using QASystem.Service.QuestionService;
using QASystem.Service.SubjectService;
using QASystem.Service.TopicService;
using QASystem.Web.Attributes;
using QASystem.Web.Helper;
using QASystem.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace QASystem.Web.Controllers
{
    public class QuestionController : Controller
    {
        private IQuestionService _questionService;
        private ITopicService _topicService;
        private ISubjectService _subjectService;

        public QuestionController(IQuestionService questionService, ITopicService topicService, ISubjectService subjectService)
        {
            _questionService = questionService;
            _topicService = topicService;
            _subjectService = subjectService;
        }

        [HttpGet]
        [LoginSkip]
        public ActionResult Index()
        {
            ViewBag.Questions = _questionService.NewestList(0, 25);
            return View();
        }


        public ActionResult Ask(QuestionViewModel questionVM = null)
        {
            var subjects = _subjectService.GetAll();
            var subjectItems = new List<SelectListItem>();
            foreach (var item in subjects)
            {
                subjectItems.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            if (questionVM.Id <= 0)
                questionVM = new QuestionViewModel()
                {
                    AuthorId = OperateContext.Current.LoginUser.Id,
                    StartTime = DateTime.UtcNow
                };
            ViewBag.SubjectItems = subjectItems;
            return View(questionVM);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult New(QuestionViewModel questionVM)
        {
            //add question
            var res = _questionService.Add(new Question()
            {
                Title = questionVM.Title,
                DateStartUtc = questionVM.StartTime,
                DateEndUtc = DateTime.UtcNow,
                Content = questionVM.Content,
                Topic = new Topic()
                {
                    SubjectId = questionVM.SubjectId,
                    Name = questionVM.TopicStr
                },
                AuthorId = questionVM.AuthorId,
                Status = (int)QuestionStatus.Published,
            });
            if (res == null)
            {
                //返回提问页面
                return Ask(questionVM);
            }
            //去问题详细页面
            return Details(res.Id);
        }

        [LoginSkip]
        public ActionResult Details(int id)
        {
            var questionVM = _questionService.GetById(id).ToViewModel();
            return View(questionVM);
        }
    }
}