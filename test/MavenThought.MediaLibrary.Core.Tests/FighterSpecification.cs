using MavenThought.Commons.Testing;
using MavenThought.MediaLibrary.Domain;

namespace MavenThought.MediaLibrary.Core.Tests
{
    /// <summary>
    /// Base specification for Ninja
    /// </summary>
    public abstract class FighterSpecification
        : AutoMockSpecification<Fighter, IFighter>
    {
    }
}