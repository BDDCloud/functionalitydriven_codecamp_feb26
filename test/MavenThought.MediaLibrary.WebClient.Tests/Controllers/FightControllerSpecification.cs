using System.Web.Mvc;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.WebClient.Controllers;

namespace MavenThought.MediaLibrary.WebClient.Tests.Controllers
{
    /// <summary>
    /// Base specification for FightController
    /// </summary>
    public abstract class FightControllerSpecification
        : AutoMockSpecificationWithNoContract<FightController>
    {
        protected ActionResult ActualResult { get; set; }
    }
}