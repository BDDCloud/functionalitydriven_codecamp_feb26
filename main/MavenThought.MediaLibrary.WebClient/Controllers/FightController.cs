using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MavenThought.MediaLibrary.Domain;

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
        /// Inject ninja commander into fight controller
        /// </summary>
        /// <param name="ninjaCommander"></param>
        public FightController(INinjaCommander ninjaCommander)
        {
            _ninjaCommander = ninjaCommander;
        }

        /// <summary>
        /// Creates the form to calculate a fight
        /// </summary>
        public ActionResult Calculator()
        {
            var ninjaListItems = _ninjaCommander.Ninjas.Select(n => new SelectListItem() { Text = n.Description });
            var opponentListItems = _ninjaCommander.Opponents.Select(n => new SelectListItem() { Text = n.Description });

            ViewData["myNinja"] = ninjaListItems;
            ViewData["opponent"] = opponentListItems;
            
            return View();
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
