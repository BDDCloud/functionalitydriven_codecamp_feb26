using System.Collections.Generic;
using System.Web.Mvc;

namespace MavenThought.MediaLibrary.WebClient.ViewModels
{
    /// <summary>
    /// ICalculatorViewModel
    /// </summary>
    public interface ICalculatorViewModel
    {
        /// <summary>
        /// list of ninjas
        /// </summary>
        IEnumerable<SelectListItem> Ninjas { get; }

        /// <summary>
        /// List of opponents
        /// </summary>
        IEnumerable<SelectListItem> Opponents { get; }
    }
}