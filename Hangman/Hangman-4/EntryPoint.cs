namespace HangMan
{
    using HangMan.GameObjects;
    using HangMan.InputProviders;
    using HangMan.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EntryPoint
    {
        private Random random = new Random();

        private static void Main()
        {
            IRenderer renderer = new Renderers.ConsoleRenderer();
            IInputProvider provider = new ConsoleInputProvider();
            Engine.Engine engine = new Engine.Engine(renderer, provider);
            engine.StartGame();
        }
    }
}
