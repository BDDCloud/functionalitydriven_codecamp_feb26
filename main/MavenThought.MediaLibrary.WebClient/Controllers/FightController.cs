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

            ViewData["MyNinja"] = new List<SelectListItem>() { 
                new SelectListItem{ Selected=true, Text="a third level black-belt", Value = "3" },
                new SelectListItem{ Text="Ninja in Training", Value = "1" } };

            ViewData["Opponent"] = new List<SelectListItem>() { 
                new SelectListItem{ Selected=true, Text="samurai", Value = "2" },
                new SelectListItem{ Text="Chuck Norris", Value = "999999" } };
            
            return View();
        }

        /// <summary>
        /// Adds a movie to the library using the title
        /// </summary>
        /// <param name="title">Title to use for the movie</param>
        /// <returns>Redirect to the index</returns>
        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Calculate()
        //{
        //    var ninjaPower = double.Parse(ViewData["MyNinja"].ToString());
        //    var opponentPower = double.Parse(ViewData["Opponent"].ToString());

        //    ViewData["result"] = ninjaPower > opponentPower ? "Engage opponent" : "Run away";

        //    return Redirect("Result");
        //}
    }
}
