namespace WindsorBTest.Core.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    /// <summary>
    /// Provides extension methods for the controller classes.
    /// </summary>
    public static class ControllerExtensions
    {
        /// <summary>
        /// Determines whether the specified type is an implementation of <see cref="IController"/>.
        /// </summary>
        /// <param name="type">The type to check.</param>
        /// <returns>
        ///    <c>true</c> if the specified type is controller; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsController(Type type)
        {
            return (((type != null)
                && type.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase))
                && !type.IsAbstract)
                && typeof(IController).IsAssignableFrom(type);
        }
    }
}
