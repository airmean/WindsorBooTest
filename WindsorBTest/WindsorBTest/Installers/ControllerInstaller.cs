namespace WindsorBTest.Installers
{
    using System.Web.Mvc;

    using Castle.Core;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(FindControllers().Configure(this.Configurer));
        }

        private void Configurer(ComponentRegistration componentRegistration)
        {
            componentRegistration.LifeStyle.Is(LifestyleType.Transient).Named(componentRegistration.Implementation.Name);
        }

        private static BasedOnDescriptor FindControllers()
        {
            return AllTypes.FromThisAssembly()
                .BasedOn<IController>()
                .If(t => t.Name.EndsWith("Controller"));
        }
    }
}