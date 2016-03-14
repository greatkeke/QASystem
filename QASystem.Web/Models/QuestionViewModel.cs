using System;
using System.ComponentModel.DataAnnotations;

namespace QASystem.Web.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public int TopicId { get; set; }
        public string TopicStr { get; set; }
        public string Content { get; set; }
        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }
        public string AuthorStr { get; set; }
        public int AuthorId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectStr { get; set; }
    }
}