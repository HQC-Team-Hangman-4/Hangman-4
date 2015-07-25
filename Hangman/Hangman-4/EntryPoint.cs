namespace HangMan
{
    using HangMan.GameObjects;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class EntryPoint
    {
        private Random random = new Random();

        private static void Main()
        {
            Engine.Engine engine = new Engine.Engine();
            engine.StartGame();
        }
    }
}
