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
using System.IO;
using System.Threading.Tasks;
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
        public string Index()
        {
            var questions = _questionService.ListBySubject(0, 0, 2);
            using (var sw = new StringWriter())
            {
                ViewData.Model = new QuestionListViewModel(questions, 0);
                var viewResult = ViewEngines.Engines.FindView(ControllerContext, "ListBySubject", "_Layout");
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                return sw.GetStringBuilder().ToString();
            }

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
                return RedirectToAction("Ask", questionVM);
            }
            //去问题详细页面
            return RedirectToAction("Details", new { id = res.Id });
        }

        [LoginSkip]
        public ActionResult Details(int id)
        {
            var questionVM = _questionService.GetByIdNoTracking(id).ToViewModel();
            return View(questionVM);
        }

        /// <summary>
        /// 展示该subject下的问题
        /// </summary>
        /// <param name="id">主题编号</param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <returns></returns>
        [LoginSkip]
        public ActionResult ListBySubject(int id, int pageIndex = 0, int pageSize = 5)
        {
            var questionListVM = new QuestionListViewModel(_questionService.ListBySubject(id, pageIndex, pageSize), id);
            return View(questionListVM);

        }
    }
}