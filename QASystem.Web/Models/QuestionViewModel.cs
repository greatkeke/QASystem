using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QASystem.Web.Models
{
    /// <summary>
    /// 问题详情-视图模型
    /// </summary>
    public class QuestionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int TopicId { get; set; }
        [Required]
        public string TopicName { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string AuthorName { get; set; }
        public int AuthorId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string NewAnswerContent { get; set; }
        public IEnumerable<AnswerViewModel> Answers { get; set; }
    }
}