using QASystem.Service.AnswerService;
using QASystem.Web.Helper;
using QASystem.Web.Models;
using System.Web.Mvc;
using System;
using QASystem.Web.Attributes;

namespace QASystem.Web.Controllers
{
    public class AnswerController : Controller
    {
        private IAnswerService _answerService;
        public AnswerController(IAnswerService answerService)
        {
            _answerService = answerService;
        }

        [ValidateInput(false)]
        [AjaxRequest]
        public PartialViewResult New(int questionId, string newAnswerContent)
        {
            var answer = _answerService.Add(questionId, newAnswerContent, OperateContext.Current.LoginUser.Id);
            if (answer != null)
            {
                var answerVM = new AnswerViewModel()
                {
                    Id = answer.Id,
                    AuthorId = answer.AuthorId,
                    AuthorName = answer.Author.Username,
                    Content = answer.Content,
                    CreateTime = TimeZoneInfo.ConvertTimeFromUtc(answer.CreateDateUtc, TimeZoneInfo.Local),
                    QuestionId = answer.QuestionId
                };
                return PartialView(answerVM);
            }
            return PartialView();
        }

    }
}