namespace HangMan.Interfaces
{
    /// <summary>
    /// Provides a common interface for word database implementations.
    /// </summary>
    public interface IWordDatabase
    {
        string GetRandomWordByCategory(Categories category);
    }
}
