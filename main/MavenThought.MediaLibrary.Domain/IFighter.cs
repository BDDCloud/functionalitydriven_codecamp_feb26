namespace MavenThought.MediaLibrary.Domain
{
    /// <summary>
    /// A fighter with attributes
    /// </summary>
    public interface IFighter
    {
        string Description { get; }

        double Strength { get; }
    }
}