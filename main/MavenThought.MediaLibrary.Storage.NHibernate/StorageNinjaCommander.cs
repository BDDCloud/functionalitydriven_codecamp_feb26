using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Cfg.Db;
using MavenThought.Commons.Extensions;
using MavenThought.MediaLibrary.Core;
using MavenThought.MediaLibrary.Domain;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace MavenThought.MediaLibrary.Storage.NHibernate
{
    /// <summary>
    /// Implementation that uses the ninja commander
    /// </summary>
    public class StorageNinjaCommander : INinjaCommander
    {
        /// <summary>
        /// Factory to obtain the session
        /// </summary>
        private readonly ISessionFactory _factory;

        /// <summary>
        /// Initializes the repository using a persistence configurer
        /// </summary>
        public StorageNinjaCommander(string databaseFile)
        {
            var configurer = SQLiteConfiguration.Standard.UsingFile(databaseFile);

#if DEBUG
            configurer.ShowSql();
#endif
            
            this._factory = SessionFactoryGateway.CreateSessionFactory(configurer, BuildSchema);
        }

        /// <summary>
        /// Constructor that injects the session factory
        /// </summary>
        /// <param name="factory">Session factory to use</param>
        public StorageNinjaCommander(ISessionFactory factory)
        {
            this._factory = factory;
        }

        /// <summary>
        /// Deletes the database if exists and creates the schema
        /// </summary>
        /// <param name="config">
        /// Configuration to use 
        /// </param>
        private static void BuildSchema(Configuration config)
        {
            // export schema
            new SchemaExport(config).Create(true, true);
        }

        /// <summary>
        /// Gets the collection of ninjas
        /// </summary>
        public IEnumerable<IFighter> Ninjas
        {
            get
            {
                var result = this._factory.List<Fighter>().Where(f => f.Class=="ninja")
                                             .Cast<IFighter>();

                return result;
            }
        }

        /// <summary>
        /// Gets the collection of opponents
        /// </summary>
        public IEnumerable<IFighter> Opponents
        {
            get
            {
                var result = this._factory.List<Fighter>().Where(f => f.Class=="opponent")
                                             .Cast<IFighter>();

                return result;
            }
        }

        /// <summary>
        /// Determine whether ninja should engage opponent
        /// </summary>
        /// <param name="ninjaDescription">description of which ninja</param>
        /// <param name="opponentDescription">description of which opponent</param>
        /// <returns>true if the ninja should engage the opponent</returns>
        public bool Engage(string ninjaDescription, string opponentDescription)
        {
            return StrengthOfNinja(ninjaDescription) > StrengthOfOpponent(opponentDescription);
        }

        /// <summary>
        /// Lookup the strength of a ninja
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        protected double StrengthOfNinja(string description)
        {
            var result = Ninjas.Find(n => n.Description == description);
            return result == null ? -1 : result.Strength;
        }

        /// <summary>
        /// Lookup the strength of an opponent
        /// </summary>
        /// <param name="description"></param>
        /// <returns></returns>
        protected double StrengthOfOpponent(string description)
        {
            var result = Opponents.Find(n => n.Description == description);
            return result == null ? -1 : result.Strength;
        }

    }
}