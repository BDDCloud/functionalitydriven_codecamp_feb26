using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;
using NHibernate;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// StorageNinjaCommander specification
    /// </summary>
    public abstract class StorageNinjaCommanderSpecification
        : AutoMockSpecification<StorageNinjaCommander, INinjaCommander>
    {
        /// <summary>
        /// Creates the ninja commander using the session factory dependency
        /// </summary>
        /// <returns>An instance to storage ninja commander</returns>
        protected override INinjaCommander CreateSut()
        {
            return new StorageNinjaCommander(Dep<ISessionFactory>());
        }
    }
}