namespace HangMan.Interfaces
{
    /// <summary>
    /// Provides common iterface for input providers.
    /// </summary>
    public interface IInputProvider
    {
        string Command { get; set; }

        void GetInput();
    }
}
