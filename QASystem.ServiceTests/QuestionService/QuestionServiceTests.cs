using Microsoft.VisualStudio.TestTools.UnitTesting;
using QASystem.ServiceTests;

namespace QASystem.Service.QuestionService.Tests
{
    [TestClass()]
    public class QuestionServiceTests
    {
        [TestMethod()]
        public void ListBySubjectTest()
        {
            var res = CommonHelper.QuestionService.ListBySubject(0, 0, 15);
            Assert.AreEqual(true, res.Count > 0);
        }
    }
}