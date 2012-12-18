namespace Naskar.Architecture.Data.Hibernate
{
    using System.Reflection;

    using FluentNHibernate.Cfg;

    using NHibernate;
    using NHibernate.Cfg;

    using Spring.Data.NHibernate;

    public class FluentNhibernateLocalSessionFactoryObject : LocalSessionFactoryObject
    {
        public string[] FluentMappingAssemblies { get; set; }

        protected override ISessionFactory NewSessionFactory(Configuration nhconfig)
        {
            var fluentConfig = Fluently.Configure(nhconfig);

            if (FluentMappingAssemblies != null)
            {
                foreach (var assemblyName in FluentMappingAssemblies)
                {
                    fluentConfig.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load(assemblyName)));
                }
            }

            return base.NewSessionFactory(fluentConfig.BuildConfiguration());
        }
    }
}
