namespace WindsorBTest.Core.Web.Castle
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Routing;

    using global::Castle.MicroKernel;

    /// <summary>
    /// The controller factory that will be used for instantiating the controllers from the Windsor IOC container.
    /// </summary>
    public class WindsorControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Kernel for resolving components
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="WindsorControllerFactory"/> class.
        /// </summary>
        /// <param name="kernel">The <see cref="IKernel"/> to use when resolving/releasing components.</param>
        public WindsorControllerFactory(IKernel kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Releases the specified controller.
        /// </summary>
        /// <param name="controller">The controller to release.</param>
        public override void ReleaseController(IController controller)
        {
            this.kernel.ReleaseComponent(controller);
        }

        /// <summary>
        /// Creates the specified controller by using the specified request context.
        /// </summary>
        /// <param name="requestContext">The context of the HTTP request, which includes the HTTP context and route data.</param>
        /// <param name="controllerName">The name of the controller.</param>
        /// <returns>A reference to the controller.</returns>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="requestContext"/> parameter is <see langword="null"/>.</exception>
        /// <exception cref="T:System.ArgumentException">The <paramref name="controllerName"/> parameter is <see langword="null"/> or empty.</exception>
        public override IController CreateController(RequestContext requestContext, string controllerName)
        {
            var controllerComponentName = controllerName + "Controller";
            return this.kernel.Resolve<IController>(controllerComponentName);
        }
    }
}
