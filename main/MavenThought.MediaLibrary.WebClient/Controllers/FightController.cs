using System.Linq;
using System.Web.Mvc;
using MavenThought.MediaLibrary.Domain;
using MavenThought.MediaLibrary.WebClient.ViewModels;

namespace MavenThought.MediaLibrary.WebClient.Controllers
{
    /// <summary>
    /// Controller for fights
    /// </summary>
    public class FightController : Controller
    {
        /// <summary>
        /// Ninja commander
        /// </summary>
        private readonly INinjaCommander _ninjaCommander;

        /// <summary>
        /// Calculator view model
        /// </summary>
        private readonly ICalculatorViewModel _calculatorViewModel;

        /// <summary>
        /// Inject ninja commander into fight controller
        /// </summary>
        /// <param name="ninjaCommander"></param>
        /// <param name="calculatorViewModel"></param>
        public FightController(INinjaCommander ninjaCommander, ICalculatorViewModel calculatorViewModel)
        {
            _ninjaCommander = ninjaCommander;
            _calculatorViewModel = calculatorViewModel;
        }

        /// <summary>
        /// Creates the form to calculate a fight
        /// </summary>
        public ActionResult Calculator()
        {
            return View(_calculatorViewModel);
        }

        /// <summary>
        /// Calculating whether to fight ro flight
        /// </summary>
        /// <param name="myNinja"></param>
        /// <param name="opponent"></param>
        /// <returns></returns>
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Calculator(string myNinja, string opponent)
        {
            var redirectUrl = _ninjaCommander.Engage(myNinja, opponent) ? Redirect("Fight") : Redirect("Flight");

            return redirectUrl;
        }

        /// <summary>
        /// Fight the opponent
        /// </summary>
        /// <returns></returns>
        public ActionResult Fight()
        {
            return View();
        }

        /// <summary>
        /// Run for his life
        /// </summary>
        /// <returns></returns>
        public ActionResult Flight()
        {
            return View();
        }
    }
}
