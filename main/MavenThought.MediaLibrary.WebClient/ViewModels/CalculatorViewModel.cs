using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.WebClient.ViewModels
{
    /// <summary>
    /// Calculator view model
    /// </summary>
    public class CalculatorViewModel : ICalculatorViewModel
    {
        /// <summary>
        /// Ninja commander
        /// </summary>
        private readonly INinjaCommander _ninjaCommander;

        /// <summary>
        /// Create calculator view model with dependencies
        /// </summary>
        /// <param name="ninjaCommander"></param>
        public CalculatorViewModel(INinjaCommander ninjaCommander)
        {
            _ninjaCommander = ninjaCommander;

            Ninjas = new SelectList(_ninjaCommander.Ninjas, "Description", "Description");
            Opponents = new SelectList(_ninjaCommander.Opponents, "Description", "Description");
        }

        /// <summary>
        /// list of ninjas
        /// </summary>
        public IEnumerable<SelectListItem> Ninjas { get; private set;}

        /// <summary>
        /// List of opponents
        /// </summary>
        public IEnumerable<SelectListItem> Opponents { get; private set; }
    }
}