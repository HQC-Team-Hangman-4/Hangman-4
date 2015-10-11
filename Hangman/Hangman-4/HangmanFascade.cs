namespace HangMan.Engine
{
    using InputProviders;
    using Interfaces;

    public static class HangmanFascade
    {   
        public static void Start()
        {
            IRenderer renderer = new Renderers.ConsoleRenderer();
            IInputProvider provider = new ConsoleInputProvider();

            Engine engine = new Engine(renderer, provider);

            engine.StartGame();
        }
    }
}
