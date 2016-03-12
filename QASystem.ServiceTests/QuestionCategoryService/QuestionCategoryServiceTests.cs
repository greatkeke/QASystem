using Microsoft.VisualStudio.TestTools.UnitTesting;
using QASystem.Core.Domain;
using QASystem.ServiceTests;
using System.Collections.Generic;
using System.Linq;

namespace QASystem.Service.QuestionCategoryService.Tests
{
    [TestClass()]
    public class QuestionCategoryServiceTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var _net = new QuestionCategory()
            {
                Name = ".Net",
                ParentId = 0
            };

            var res = CommonHelper.QuestionCategoryService.Add(_net);
            Assert.AreEqual(true, res);

        }

        [TestMethod()]
        public void UpdateTest()
        {
            var mvc = CommonHelper.QuestionCategoryService.Table.FirstOrDefault(u => u.Name == "MVC");
            mvc.ParentId = CommonHelper.QuestionCategoryService.Table.FirstOrDefault(u => u.Name == "Web网络编程").Id;
            var res = CommonHelper.QuestionCategoryService.Update(mvc);
            Assert.AreEqual(true, res);
        }

        [TestMethod()]
        public void GetAllTest()
        {
            var all = CommonHelper.QuestionCategoryService.GetAll();
            Assert.AreEqual(true, all.Count() > 0);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var mvc = CommonHelper.QuestionCategoryService.Table.FirstOrDefault(u => u.Id == 4);
            var res = CommonHelper.QuestionCategoryService.Delete(mvc);
            Assert.AreEqual(true,res);
        }

        [TestMethod()]
        public void AddTest1()
        {
            var task = new QuestionCategory()
            {
                Name = "Task异步编程",
                ParentId = 1
            };
            var web = new QuestionCategory()
            {
                Name = "Web网络编程",
                ParentId = 1
            };
            var mvc = new QuestionCategory()
            {
                Name = "MVC",
                ParentId = web.Id
            };
            var res = CommonHelper.QuestionCategoryService.Add(new List<QuestionCategory>()
            {
                task,web,mvc
            });
            Assert.AreEqual(true, res.Result);
        }
    }
}