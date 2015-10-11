namespace HangMan
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using HangMan.GameObjects;
    using HangMan.Helpers;
    using HangMan.InputProviders;
    using HangMan.Interfaces;    

    public class EntryPoint
    {
        private Random random = new Random();

        private static void Main()
        {
            IRenderer renderer = new Renderers.ConsoleFancyRenderer();
            IInputProvider provider = new ConsoleInputProvider();
            Engine.Engine engine = new Engine.Engine(renderer, provider);
            engine.StartGame();
        }
    }
}
