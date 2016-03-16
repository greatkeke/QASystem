using QASystem.Core.Domain;
using System;
using System.Linq;

namespace QASystem.Web.Models
{
    public static class ModelExtensions
    {
        public static QuestionViewModel ToViewModel(this Question question)
        {
            return new QuestionViewModel()
            {
                AuthorId = question.AuthorId,
                Content = question.Content,
                EndTime = TimeZoneInfo.ConvertTimeFromUtc(question.DateEndUtc, TimeZoneInfo.Local),
                Id = question.Id,
                StartTime = TimeZoneInfo.ConvertTimeFromUtc(question.DateStartUtc, TimeZoneInfo.Local),
                SubjectId = question.Topic.SubjectId,
                SubjectName = question.Topic.Subject.Name,
                TopicName = question.Topic.Name,
                TopicId = question.TopicId,
                Title = question.Title,
                AuthorName = question.Author.Username,
                Answers = question.Answers.Select(u => u.ToViewModel())
            };
        }

        public static AnswerViewModel ToViewModel(this Answer answer)
        {
            return new AnswerViewModel()
            {
                Id = answer.Id,
                AuthorId = answer.AuthorId,
                AuthorName = answer.Author.Username,
                Content = answer.Content,
                CreateTime = TimeZoneInfo.ConvertTimeFromUtc(answer.CreateDateUtc, TimeZoneInfo.Local),
                QuestionId = answer.QuestionId,
            };
        }
    }
}