﻿using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.Core
{
    /// <summary>
    /// Implementation of opponent
    /// </summary>
    public class Opponent : IFighter
    {
        /// <summary>
        /// Gets or sets the id of the figter
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Description of fighter
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Strength of fighter
        /// </summary>
        public virtual double Strength { get; set; }
    }
}