using QASystem.Service.QuestionCategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QASystem.Web.Controllers
{
    public class QuestionCategoryController : Controller
    {
        private IQuestionCategoryService _questionCategoryService;

        public QuestionCategoryController(IQuestionCategoryService questionCategoryService)
        {
            _questionCategoryService = questionCategoryService;
        }
        // GET: QuestionCategory
        public ActionResult Index()
        {
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult List()
        {
            //获取所有的分类
            ViewBag.Cates = _questionCategoryService.GetAll();
            return PartialView();
        }
    }
}