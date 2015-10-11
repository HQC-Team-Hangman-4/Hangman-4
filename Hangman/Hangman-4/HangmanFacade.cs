namespace HangMan.Engine
{
    using InputProviders;
    using Interfaces;

    public static class HangmanFacade
    {   
        public static void Start()
        {
            IRenderer renderer = new Renderers.ConsoleFancyRenderer();
            IInputProvider provider = new ConsoleInputProvider();

            Engine engine = new Engine(renderer, provider);

            engine.StartGame();
        }
    }
}
