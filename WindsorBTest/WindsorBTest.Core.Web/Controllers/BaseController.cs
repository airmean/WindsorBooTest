namespace WindsorBTest.Core.Web.Controllers
{
    using System.Web.Mvc;

    using global::Castle.Core.Logging;

    public class BaseController : Controller
    {
        // this is Castle.Core.Logging.ILogger, not log4net.Core.ILogger
        public ILogger Logger { get; set; }
    }
}
