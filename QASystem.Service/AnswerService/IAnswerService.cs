using QASystem.Core.Domain;

namespace QASystem.Service.AnswerService
{
    public interface IAnswerService
    {
        Answer Add(int questionId, string answerContent, int anthorId);
    }
}
