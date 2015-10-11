using HangMan.Engine;

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
        private static void Main()
        {
            HangmanFacade.Start();
        }
    }
}
