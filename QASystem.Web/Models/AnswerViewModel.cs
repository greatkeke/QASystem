using System;

namespace QASystem.Web.Models
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public DateTime CreateTime { get; set; }
        public int QuestionId { get; set; }
    }
}