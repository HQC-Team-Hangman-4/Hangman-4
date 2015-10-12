namespace HangMan.Interfaces
{
    /// <summary>
    /// Provides common iterface for input providers.
    /// </summary>
    public interface IInputProvider
    {
        /// <summary>
        /// Gets and sets the command.
        /// </summary>
        string Command { get; set; }

        /// <summary>
        /// Reads a command.
        /// </summary>
        void GetInput();
    }
}
