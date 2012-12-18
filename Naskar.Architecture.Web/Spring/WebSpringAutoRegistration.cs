namespace Naskar.Architecture.Web.Spring
{
    using System.Web.Mvc;

    using global::Spring.AutoRegistration;
    using global::Spring.Context;
    using global::Spring.Context.Support;

    public class WebSpringAutoRegistration : IApplicationContextAware
    {
        public string[] Namespaces { get; set; }

        public IApplicationContext ApplicationContext
        {
            set
            {
                Register((AbstractApplicationContext)value);
            }
        }

        public void Register(AbstractApplicationContext context)
        {
            var registration = context.Configure();

            foreach (var name in Namespaces)
            {
                registration.IncludeAssembly(x => x.FullName.StartsWith(name));
            }

            registration
                .Include(If.DecoratedWith<NamedAttribute>, 
                    Then.Register().UsingSingleton().InjectByProperty(If.DecoratedWith<InjectAttribute>))
                .Include(If.Implements<IController>, 
                    Then.Register().UsingPrototype().InjectByProperty(If.DecoratedWith<InjectAttribute>))
                .ApplyAutoRegistration();
        }
    }
}