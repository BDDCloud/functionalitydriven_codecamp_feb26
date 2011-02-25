using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.Core.Tests
{
    /// <summary>
    /// Base specification for Movie
    /// </summary>
    public abstract class NinjaSpecification
        : AutoMockSpecification<Ninja, IFighter>
    {
    }
}