using Autofac;
using Autofac.Integration.Mvc;
using QASystem.Core;
using QASystem.Data;
using QASystem.Service.QuestionCategoryService;
using QASystem.Service.UserService;
using System.Reflection;
using System.Web.Mvc;

namespace QASystem.Web.Infrastructure
{
    public class DependenceRegistrar
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            // builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).AsImplementedInterfaces();
            builder.Register<IUnitOfWork>(a => new QASystemDbContext("QASystemDb")).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>));
            //类型注入
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<QuestionCategoryService>().As<IQuestionCategoryService>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}