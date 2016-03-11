namespace QASystem.Data
{
    using Core;
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Reflection;
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class QASystemDbContext : DbContext, IUnitOfWork
    {
        public QASystemDbContext()
            : base("name=QASystemDb")
        {
        }
        public QASystemDbContext(string connectionStrOrName)
           : base(connectionStrOrName)
        {
            //启用延时加载
            Configuration.LazyLoadingEnabled = true;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            .Where(type => !String.IsNullOrEmpty(type.Namespace))
            .Where(type => type.BaseType != null && type.BaseType.IsGenericType &&
                type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
            //...or do it manually below. For example,
            //modelBuilder.Configurations.Add(new LanguageMap());

            base.OnModelCreating(modelBuilder);
        }

    }


}