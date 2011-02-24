using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MavenThought.MediaLibrary.WebClient.Controllers
{
    /// <summary>
    /// Controller for fights
    /// </summary>
    public class FightController : Controller
    {
       
        /// <summary>
        /// Creates the form to calculate a fight
        /// </summary>
        public ActionResult Calculator()
        {
            ViewData["myNinja"] = new List<SelectListItem>() { 
                new SelectListItem{ Selected=true, Text="a third level black-belt", Value = "3" },
                new SelectListItem{ Text="ninja in training", Value = "1" } };

            ViewData["opponent"] = new List<SelectListItem>() { 
                new SelectListItem{ Selected=true, Text="a samurai", Value = "2" },
                new SelectListItem{ Text="Chuck Norris", Value = "4" } };
            
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
            var ninjaPower = CalculateStrengthOfFighter(myNinja);
            var opponentPower = CalculateStrengthOfFighter(opponent);

            var redirectUrl = ninjaPower > opponentPower ? Redirect("Fight") : Redirect("Flight");

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

        /// <summary>
        /// Calculate strength of fighter
        /// </summary>
        /// <param name="fighter"></param>
        /// <returns>The strength of that fighter</returns>
        private double CalculateStrengthOfFighter(string fighter)
        {
            switch (fighter)
            {
                case "1":
                    return 1;
                case "3":
                    return 3;
                case "2":
                    return 2;
                case "4":
                    return double.MaxValue;
                default:
                    return -1;
            }
        }
    }
}
