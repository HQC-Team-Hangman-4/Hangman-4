namespace HangMan.Engine
{
    using InputProviders;
    using Interfaces;

    /// <summary>
    /// A facade for game setup.
    /// </summary>
    public static class HangmanFacade
    {   
        /// <summary>
        /// Start method which hides game setup.
        /// </summary>
        public static void Start()
        {
            IRenderer renderer = new Renderers.ConsoleFancyRenderer();
            IInputProvider provider = new ConsoleInputProvider();

            Engine engine = new Engine(renderer, provider);

            engine.StartGame();
        }
    }
}
