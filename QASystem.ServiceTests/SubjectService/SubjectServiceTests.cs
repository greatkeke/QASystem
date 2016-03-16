using Microsoft.VisualStudio.TestTools.UnitTesting;
using QASystem.ServiceTests;
using System.Linq;

namespace QASystem.Service.SubjectService.Tests
{
    [TestClass()]
    public class SubjectServiceTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            var res = CommonHelper.SubjectService.GetAll();
            Assert.AreEqual(true, res.Count() > 0);
        }
    }
}