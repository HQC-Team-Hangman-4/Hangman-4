namespace HangMan
{
    using HangMan.Engine;

    /// <summary>
    /// An entry point from where the game can be launched.
    /// </summary>
    public class EntryPoint
    {
        private static void Main()
        {
            HangmanFacade.Start();
        }
    }
}
