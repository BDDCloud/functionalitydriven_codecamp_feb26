using FluentNHibernate.Testing;
using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Core;

namespace MavenThought.MediaLibrary.Storage.NHibernate.Tests
{
    /// <summary>
    /// Specification when persistent product is created
    /// </summary>
    [ConstructorSpecification]
    public class When_fighter_is_created : PersistentFighterSpecification
    {
        /// <summary>
        /// Validates the mapping
        /// </summary>
        [It]
        public void Should_have_the_right_mappings()
        {
            this.Sut.AutoSession(s =>
                                     new PersistenceSpecification<Fighter>(s)
                                         .CheckProperty(p => p.Strength, 20)
                                         .CheckProperty(p => p.Description, "third dan black belt")
                                         .CheckProperty(p => p.Class, "ninja")
                                         .VerifyTheMappings());
        }
    }
}