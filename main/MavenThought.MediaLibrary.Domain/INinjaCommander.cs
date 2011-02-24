using System.Collections.Generic;

namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// Ninja commanders intelligence information
    /// </summary>
    public interface INinjaCommander
    {
        /// <summary>
        /// Gets the collection of ninjas
        /// </summary>
        IEnumerable<IFighter> Ninjas { get; }

        /// <summary>
        /// Gets the collection of opponents
        /// </summary>
        IEnumerable<IFighter> Opponents { get; }

        /// <summary>
        /// Determine whether ninja should engage opponent
        /// </summary>
        /// <param name="ninjaDescription">description of which ninja</param>
        /// <param name="opponentDescription">description of which opponent</param>
        /// <returns>true if the ninja should engage the opponent</returns>
        bool Engage(string ninjaDescription, string opponentDescription);
    }
}