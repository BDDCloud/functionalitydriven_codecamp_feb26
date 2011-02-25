using FluentNHibernate.Testing;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Core;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Specification when persistent product is created
    /// </summary>
    [ConstructorSpecification]
    public class When_ninja_is_created : PersistentNinjaSpecification
    {
        /// <summary>
        /// Validates the mapping
        /// </summary>
        [It]
        public void Should_have_the_right_mappings()
        {
            this.Sut.AutoSession(s =>
                                     new PersistenceSpecification<Ninja>(s)
                                         .CheckProperty(p => p.Strength, "Space Balls")
                                         .CheckProperty(p => p.Description, "Space Balls")
                                         .VerifyTheMappings());
        }
    }
}